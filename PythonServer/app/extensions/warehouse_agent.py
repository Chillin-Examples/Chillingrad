# -*- coding: utf-8 -*-

# python imports
from copy import deepcopy

# project imports
from ..ks import models
from ..ks.models import Agent, AgentType, ECell
from ..gui_events import GuiEvent, GuiEventType


class WarehouseAgent(Agent):

    def move(self, world, side, forward):
        if forward and world.bases[side].c_area[self.position] != ECell.BacklineDelivery:
            self.position.index += 1
        elif not forward and self.position.index > 0:
            self.position.index -= 1
        else:
            return []
        return [GuiEvent(GuiEventType.Move, side=side, agent=self)]


    def pick_material(self, world, side):
        base = world.bases[side]

        if sum(self.materials_bag.values()) >= self.c_materials_bag_capacity:
            return []

        if not (base.c_area[self.position] == ECell.Material and
                base.warehouse.materials[self.position].count > 0):
            return []

        material = base.warehouse.materials[self.position]
        self.materials_bag[material.type] += 1
        material.count -= 1
        return [GuiEvent(GuiEventType.PickMaterial, agent=self, material=material)]


    def put_material(self, world, side):
        base = world.bases[side]

        if base.c_area[self.position] != ECell.BacklineDelivery:
            return []

        for material_type, count in self.materials_bag.items():
            base.backline_delivery.materials[material_type] += count
            self.materials_bag[material_type] = 0
        return [GuiEvent(GuiEventType.PutMaterial, agent=self)]


    def pick_ammo(self, world, side, ammos):
        base = world.bases[side]

        for ammo_type, count in ammos.items():
            if count <= 0 or count > base.backline_delivery.ammos[ammo_type]:
                return []

        if base.c_area[self.position] != ECell.BacklineDelivery:
            return []

        if sum(ammos.values()) + sum(self.ammos_bag.values()) > self.c_ammos_bag_capacity:
            return []

        for ammo_type, count in ammos.items():
            self.ammos_bag[ammo_type] += count
            base.backline_delivery.ammos[ammo_type] -= count
        return [GuiEvent(GuiEventType.PickAmmo, agent=self, ammos=ammos)]


    def put_ammo(self, world, side):
        base = world.bases[side]

        if base.c_area[self.position] != ECell.FrontlineDelivery:
            return []

        if sum(self.ammos_bag.values()) <= 0:
            return []

        frontline_delivery = deepcopy(base.default_frontline_delivery)
        base.frontline_deliveries.append(frontline_delivery)
        for ammo_type, count in self.ammos_bag.items():
            frontline_delivery.ammos[ammo_type] = count
            self.ammos_bag[ammo_type] = 0
        return [GuiEvent(GuiEventType.PutAmmo, agent=self)]


models.WarehouseAgent = WarehouseAgent
