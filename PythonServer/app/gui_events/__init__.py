# -*- coding: utf-8 -*-

# python imports
from enum import Enum


class GuiEventType(Enum):
    Move = 0
    PickMaterial = 1
    PutMaterial = 2
    PickAmmo = 3
    PutAmmo = 4

    WarehouseReload = 5

    MachineAmmoReady = 6

    UnitDied = 7


class GuiEvent(object):

    def __init__(self, type, **kwargs):
        self.type = type
        self.__dict__.update(kwargs)
