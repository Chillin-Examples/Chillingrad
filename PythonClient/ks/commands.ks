[CommandMaterialType]
_def = enum <byte>
    {
        Powder,
        Steel,
        Aluminum,
        Shell,
        Nickel,
        Manganese,
        Chromium
    }


[CommandAmmoType]
_def = enum <byte>
    {
        RifleBullet,
        TankShell,
        Bomb,
        ArtilleryShell,
        HMGBullet
    }


[CommandAgentType]
_def = enum <byte>
    {
        Warehouse,
        Factory
    }


##############################################################

[BaseCommand]
_def = class
agent_type = CommandAgentType


[Move]
_def = class(BaseCommand)
forward = boolean


[PickMaterial]
_def = class(BaseCommand)
materials = map<CommandMaterialType, int>


[PutMaterial]
_def = class(BaseCommand)
materials = map<CommandMaterialType, int>


[PickAmmo]
_def = class(BaseCommand)
ammos = map<CommandAmmoType, int>


[PutAmmo]
_def = class(BaseCommand)
