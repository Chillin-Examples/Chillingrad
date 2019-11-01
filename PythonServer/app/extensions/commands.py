### This extension should be removed after adding 'import' feature to the koala-serializer ###

# project imports
from ..ks import models
from ..ks import commands


commands.CommandMaterialType = models.MaterialType
commands.CommandAmmoType = models.AmmoType
commands.CommandAgentType = models.AgentType
