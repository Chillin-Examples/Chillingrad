# -*- coding: utf-8 -*-

# python imports
from enum import Enum


class GuiEventType(Enum):
    Move = 0
    PickMaterial = 1
    PutMaterial = 2
    PickAmmo = 3
    PutAmmo = 4

    UnitDied = 5

    MachineIdle = 6
    MachineWorking = 7
    MachineAmmoReady = 8


class GuiEvent(object):

    def __init__(self, type, **kwargs):
        self.type = type
        self.__dict__.update(kwargs)
