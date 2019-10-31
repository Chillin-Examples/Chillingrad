# -*- coding: utf-8 -*-

# project imports
from ..ks.models import World, AgentType, WarehouseAgent, FactoryAgent
from ..ks.commands import Move, PickMaterial, PutMaterial, PickAmmo, PutAmmo
from ..gui_events import GuiEvent, GuiEventType


METHOD = lambda world, side, command: {
    Move.name(): world.bases[side].agents[command.agent_type].move,
    PickMaterial.name(): world.bases[side].agents[command.agent_type].pick_material,
    PutMaterial.name(): world.bases[side].agents[command.agent_type].put_material,
    PickAmmo.name(): world.bases[side].agents[command.agent_type].pick_ammo,
    PutAmmo.name(): world.bases[side].agents[command.agent_type].put_ammo
}.get(command.name())

ARGS = lambda command: {
    Move.name(): \
        lambda command: (command.forward,),
    PickMaterial.name(): \
        lambda command: (command.materials,) if command.agent_type == AgentType.Factory else (),
    PutMaterial.name(): \
        lambda command: (command.desired_ammo,) if command.agent_type == AgentType.Factory else (),
    PickAmmo.name(): \
        lambda command: (command.ammos,) if command.agent_type == AgentType.Warehouse else (),
    PutAmmo.name(): \
        lambda command: ()
}[command.name()](command)


def apply_commands(self, commands):
    gui_events = []

    for side in commands:
        for command in commands[side].values():
            method = METHOD(self, side, command)
            if method is not None:
                args = ARGS(command)
                gui_events.extend(method(self, side, *args))

    return gui_events


def tick(self):
    gui_events = []
    gui_events.extend(self._tick_war())
    gui_events.extend(self._tick_bases())
    return gui_events


def _tick_war(self):
    gui_events = []
    return gui_events


def _tick_bases(self):
    gui_events = []

    for side, base in self.bases.items():
        for frontline_delivery in base.frontline_deliveries[:]:
            gui_events.extend(frontline_delivery.tick(self, side))
        gui_events.extend(base.warehouse.tick(self, side))
        gui_events.extend(base.factory.tick(self, side))

    return gui_events


World.apply_commands = apply_commands
World.tick = tick
World._tick_war = _tick_war
World._tick_bases = _tick_bases
