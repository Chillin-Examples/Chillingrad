# -*- coding: utf-8 -*-

# project imports
from ..ks import models
from ..ks.models import Agent, AgentType, ECell, MachineStatus
from ..gui_events import GuiEvent, GuiEventType


class FactoryAgent(Agent):

    def move(self, world, side, forward):
        if forward and self.position.index < len(world.bases[side].c_area) - 1:
            self.position.index += 1
        elif not forward and world.bases[side].c_area[self.position] != ECell.BacklineDelivery:
            self.position.index -= 1
        else:
            return []
        return [GuiEvent(GuiEventType.Move, side=side, agent=self)]


    def pick_material(self, world, side, materials):
        base = world.bases[side]

        for material_type, count in materials.items():
            if count <= 0 or count > base.backline_delivery.materials[material_type]:
                return []

        if base.c_area[self.position] != ECell.BacklineDelivery:
            return []

        if sum(materials.values()) + sum(self.materials_bag.values()) > self.c_materials_bag_capacity:
            return []

        for material_type, count in materials.items():
            self.materials_bag[material_type] += count
            base.backline_delivery.materials[material_type] -= count
        return [GuiEvent(GuiEventType.PickMaterial, agent=self, materials=materials)]


    def put_material(self, world, side, desired_ammo):
        base = world.bases[side]

        if not (base.c_area[self.position] == ECell.Machine and
                base.factory.machines[self.position].status == MachineStatus.Idle):
            return []

        mixture_formula = base.factory.c_mixture_formulas[desired_ammo]
        for material_type, count in mixture_formula.items():
            if self.materials_bag[material_type] < count:
                return []

        for material_type, count in mixture_formula.items():
            self.materials_bag[material_type] -= count
        machine = base.factory.machines[self.position]
        machine.status = MachineStatus.Working
        machine.current_ammo = desired_ammo
        machine.construction_rem_time = base.factory.c_construction_durations[desired_ammo]

        return [GuiEvent(GuiEventType.PutMaterial, agent=self, machine=machine)]


    def pick_ammo(self, world, side):
        base = world.bases[side]

        if not (base.c_area[self.position] == ECell.Machine and
                base.factory.machines[self.position].status == MachineStatus.AmmoReady):
            return []

        if sum(self.ammos_bag.values()) >= self.c_ammos_bag_capacity:
            return []

        machine = base.factory.machines[self.position]
        self.ammos_bag[machine.current_ammo] += 1
        machine.status = MachineStatus.Idle
        machine.current_ammo = None
        return [GuiEvent(GuiEventType.PickAmmo, agent=self, machine=machine)]


    def put_ammo(self, world, side):
        base = world.bases[side]

        if base.c_area[self.position] != ECell.BacklineDelivery:
            return []

        if sum(self.ammos_bag.values()) <= 0:
            return []

        for ammo_type, count in self.ammos_bag.items():
            base.backline_delivery.ammos[ammo_type] += count
            self.ammos_bag[ammo_type] = 0
        return [GuiEvent(GuiEventType.PutAmmo, agent=self)]


models.FactoryAgent = FactoryAgent
