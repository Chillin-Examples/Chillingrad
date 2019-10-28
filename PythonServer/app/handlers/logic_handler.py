# -*- coding: utf-8 -*-

# python imports
from copy import deepcopy

# project imports
from ..ks.models import World


class LogicHandler:

    def __init__ (self, world, sides):
        self._sides = sides
        self.world = world


    def initialize(self):
        self.clear_commands()


    def store_command(self, side_name, command):
        pass  # TODO: validate and store commands


    def clear_commands(self):
        self._last_cycle_commands = {side: {} for side in self._sides}


    def process(self, current_cycle):
        gui_events = []

        for side in self._sides:
            for agentType in self._last_cycle_commands[side]:
                command = self._last_cycle_commands[side][agentType]

                gui_events += self.world.apply_command(side, command)

        # TODO: Add other logics

        return gui_events


    def get_client_world(self, side_name):
        return self.world  # TODO: Add fog of war


    def check_end_game(self, current_cycle):
        end_game = False
        winner = None
        details = None

        if current_cycle >= self.world.max_cycles - 1:
            end_game = True

        # TODO: Add other end game conditions

        if end_game:
            if self.world.total_healths['Allies'] > self.world.total_healths['Axis']:
                winner = 'Allies'
            elif self.world.total_healths['Axis'] > self.world.total_healths['Allies']:
                winner = 'Axis'

            details = {
                'Remaining Healths': {
                    'Allies': str(self.world.total_healths['Allies']),
                    'Axis': str(self.world.total_healths['Axis'])
                }
            }

        return end_game, winner, details
