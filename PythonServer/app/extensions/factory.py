# -*- coding: utf-8 -*-

# project imports
from ..ks.models import Factory, MachineStatus
from ..gui_events import GuiEvent, GuiEventType


def tick(self, world, side):
    gui_events = []

    for machine in self.machines.values():
        if machine.status == MachineStatus.Working:
            machine.construction_rem_time -= 1

            if machine.construction_rem_time <= 0:
                machine.status = MachineStatus.AmmoReady
                gui_events.append(GuiEvent(GuiEventType.MachineAmmoReady, side=side, machine=machine))

    return gui_events


Factory.tick = tick
