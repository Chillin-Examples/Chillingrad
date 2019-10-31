# -*- coding: utf-8 -*-

# python imports
import json
from copy import deepcopy

# project imports
from ..ks.models import *


class MapHandler:

    def __init__(self, sides):
        self._sides = sides


    def _create_base(self, map_info):
        m = map_info
        base = Base()

        # Area
        base.c_area = { Position(i): ECell.Empty for i in range(m['area']['length']) }

        # Agents
        base.agents = {}
        for agent_type in AgentType:
            AgentClass = WarehouseAgent if agent_type == AgentType.Warehouse else FactoryAgent
            base.agents[agent_type] = AgentClass(
                type = agent_type,
                position = Position(index = m['agents'][agent_type.name]['position']),
                materials_bag = { material_type: 0 for material_type in MaterialType },
                c_materials_bag_capacity = m['agents']['c_materials_bag_capacity'],
                ammos_bag = { ammo_type: 0 for ammo_type in AmmoType },
                c_ammos_bag_capacity = m['agents']['c_ammos_bag_capacity'],
            )

        # Frontline Delivery
        base.c_area[Position(m['frontline_delivery']['position'])] = ECell.FrontlineDelivery
        base.frontline_deliveries = []

        ## Extra Info
        base.default_frontline_delivery = FrontlineDelivery(
            ammos = { ammo_type: 0 for ammo_type in AmmoType },
            delivery_rem_time = m['frontline_delivery']['c_delivery_duration'],
            c_delivery_duration = m['frontline_delivery']['c_delivery_duration']
        )

        # Warehouse
        warehouse_materials = {}
        for material in m['warehouse']['materials']:
            position = Position(index = material['position'])
            base.c_area[position] = ECell.Material

            warehouse_materials[position] = Material(
                type = MaterialType[material['type']],
                position = position,
                count = material['c_capacity'],
                c_capacity = material['c_capacity'],
            )

        base.warehouse = Warehouse(
            materials = warehouse_materials,
            materials_reload_rem_time = m['warehouse']['c_materials_reload_duration'],
            c_materials_reload_duration = m['warehouse']['c_materials_reload_duration'],
        )

        # Backline Delivery
        base.c_area[Position(m['backline_delivery']['position'])] = ECell.BacklineDelivery

        base.backline_delivery = BacklineDelivery(
            materials = { material_type: 0 for material_type in MaterialType },
            ammos = { ammo_type: 0 for ammo_type in AmmoType },
        )

        # Factory
        factory_machines = {}
        for machine_position in m['factory']['machine_positions']:
            position = Position(index = machine_position)
            base.c_area[position] = ECell.Machine

            factory_machines[position] = Machine(
                position = position,
                status = MachineStatus.Idle,
                current_ammo = None,
                construction_rem_time = 0,
            )

        c_mixture_formulas = {}
        for ammo_type in AmmoType:
            c_mixture_formulas[ammo_type] = {}
            for material_type, count in m['factory']['c_mixture_formulas'][ammo_type.name].items():
                c_mixture_formulas[ammo_type][MaterialType[material_type]] = count

        base.factory = Factory(
            machines = factory_machines,
            c_mixture_formulas = c_mixture_formulas,
            c_construction_durations = {
                ammo_type: m['factory']['c_construction_durations'][ammo_type.name]
                for ammo_type in AmmoType
            },
            c_ammo_box_sizes = {
                ammo_type: m['factory']['c_ammo_box_sizes'][ammo_type.name] for ammo_type in AmmoType
            }
        )

        # Units
        base.units = {}
        for unit_type_name, unit_info in m['units'].items():
            unit_type = UnitType[unit_type_name]
            base.units[unit_type] = Unit(
                type = unit_type,
                health = unit_info['count'] * unit_info['c_individual_health'],
                c_individual_health = unit_info['c_individual_health'],
                c_individual_damage = unit_info['c_individual_damage'],
                c_damage_distribution = {
                    ut: m['units'][unit_type_name]['c_damage_distribution'][ut.name] for ut in UnitType
                },
                ammo_count = unit_info['ammo_count'],
                reload_rem_time = unit_info['c_reload_duration'],
                c_reload_duration = unit_info['c_reload_duration'],
            )

            # Extra info
            base.units[unit_type].count = unit_info['count']

        # return
        return base


    def load_map(self, config):
        with open((config['map_path']), 'r') as map_file:
            map_info = json.loads(map_file.read())

        base = self._create_base(map_info)
        total_healths = sum([unit.health for unit in base.units.values()])

        # Create world
        world = World(
            max_cycles = map_info['max_cycles'],
            bases = {side: deepcopy(base) for side in self._sides},
            total_healths = {side: total_healths for side in self._sides},
        )

        # Extra info
        world.location = map_info['location']

        return world
