# -*- coding: utf-8 -*-

# python imports
import json
from copy import deepcopy

# project imports
from ..ks.models import *


class MapHandler:

    def __init__(self, sides):
        self._sides = sides


    def _create_base(self, m):
        base = Base()

        # Area
        base.c_area = [ECell.Empty] * m['area']['length']

        # Agents
        base.agents = {}
        for agentType in AgentType:
            base.agents[agentType] = Agent(
                type = agentType,
                position = Position(index = m['agents'][agentType.name]['position']),
                materials_bag = { materialType: 0 for materialType in MaterialType },
                c_materials_bag_capacity = m['agents']['c_materials_bag_capacity'],
                ammos_bag = { ammoType: 0 for ammoType in AmmoType },
                c_ammos_bag_capacity = m['agents']['c_ammos_bag_capacity'],
            )

        # Frontline Delivery
        base.c_area[m['frontline_delivery']['position']] = ECell.FrontlineDelivery

        base.frontline_delivery = FrontlineDelivery(
            is_available = True,
            ammos = { ammoType: 0 for ammoType in AmmoType },
            truck_delivery_rem_time = 0,
            c_truck_delivery_duration = m['frontline_delivery']['c_truck_delivery_duration'],
            truck_return_rem_time = 0,
            c_truck_return_duration = m['frontline_delivery']['c_truck_return_duration'],
        )

        # Repository
        repo_materials = {}
        for material in m['repository']['materials']:
            position = Position(index = material['position'])
            base.c_area[position.index] = ECell.Material

            repo_materials[position] = Material(
                type = MaterialType[material['type']],
                position = position,
                count = material['c_capacity'],
                c_capacity = material['c_capacity'],
            )

        base.repository = Repository(
            materials = repo_materials,
            materials_reload_rem_time = m['repository']['c_materials_reload_duration'],
            c_materials_reload_duration = m['repository']['c_materials_reload_duration'],
        )

        # Backline Delivery
        base.c_area[m['backline_delivery']['position']] = ECell.BacklineDelivery

        base.backline_delivery = BacklineDelivery(
            materials = { materialType: 0 for materialType in MaterialType },
            ammos = { ammoType: 0 for ammoType in AmmoType },
        )

        # Factory
        factory_machines = {}
        for machine_position in m['factory']['machines_position']:
            position = Position(index = machine_position)
            base.c_area[position.index] = ECell.Machine

            factory_machines[position] = Machine(
                status = MachineStatus.Idle,
                position = position,
                current_ammo = None,  # TODO: Should it change to some value?
                construction_rem_time = 0,
            )

        c_mixture_formulas = {}
        for ammoType in AmmoType:
            c_mixture_formulas[ammoType] = {}
            for materialType, count in m['factory']['c_mixture_formulas'][ammoType.name].items():
                c_mixture_formulas[ammoType][MaterialType[materialType]] = count

        base.factory = Factory(
            machines = factory_machines,
            c_mixture_formulas = c_mixture_formulas,
            c_construction_durations = {ammoType: m['factory']['c_construction_durations'][ammoType.name]
                                            for ammoType in AmmoType},
            c_ammo_box_sizes = {ammoType: m['factory']['c_ammo_box_sizes'][ammoType.name]
                                            for ammoType in AmmoType}
        )

        # Units
        base.units = {}
        for mUnitType, mUnit in m['units'].items():
            unitType = UnitType[mUnitType]
            base.units[unitType] = Unit(
                type = unitType,
                health = mUnit['count'] * mUnit['c_individual_health'],
                c_individual_health = mUnit['c_individual_health'],
                c_individual_damage = mUnit['c_individual_damage'],
                c_damage_distribution = {uType: m['units'][mUnitType]['c_damage_distribution'][uType.name]
                                            for uType in UnitType},
                ammo_count = mUnit['ammo_count'],
                reload_rem_time = mUnit['c_reload_duration'],
                c_reload_duration = mUnit['c_reload_duration'],
            )
            # Extra infos
            base.units[unitType].count = mUnit['count']

        # return
        return base


    def _calc_total_healths(self, base):
        total_healths = 0

        for unit in base.units.values():
            total_healths += unit.health

        return total_healths


    def load_map(self, config):
        with open((config['map_path']), 'r') as map_file:
            m = json.loads(map_file.read())

        base = self._create_base(m)
        total_healths = self._calc_total_healths(base)

        # Create world
        world = World(
            max_cycles = m['max_cycles'],
            bases = {side: deepcopy(base) for side in self._sides},
            total_healths = {side: total_healths for side in self._sides},
        )

        return world
