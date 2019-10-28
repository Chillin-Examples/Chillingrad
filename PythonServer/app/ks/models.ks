[ECell]
_def = enum <byte>
    {
        Empty,
        FrontlineDelivery,
        Material,
        BacklineDelivery,
        Machine
    }


[MachineStatus]
_def = enum <byte>
    {
        Idle,
        Working,
        AmmoReady
    }


[MaterialType]
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


[AmmoType]
_def = enum <byte>
    {
        RifleBullet,
        TankShell,
        Bomb,
        ArtilleryShell,
        HMGBullet
    }


[UnitType]
_def = enum <byte>
    {
        Soldier,
        Tank,
        Aircraft,
        Artillery,
        HeavyMachineGunner
    }


[AgentType]
_def = enum <byte>
    {
        Repository,
        Factory
    }


##############################################################

[Position]
_def = class
index = int


[Material]
_def = class
type = MaterialType
position = Position
count = int
c_capacity = int


[Machine]
_def = class
status = MachineStatus
position = Position
current_ammo = AmmoType
construction_rem_time = int


##############################################################

[FrontlineDelivery]
_def = class
is_available = boolean
ammos = map<AmmoType, int>
truck_delivery_rem_time = int
c_truck_delivery_duration = int
truck_return_rem_time = int
c_truck_return_duration = int


[Repository]
_def = class
materials = map<Position, Material>
materials_reload_rem_time = int
c_materials_reload_duration = int


[BacklineDelivery]
_def = class
materials = map<MaterialType, int>
ammos = map<AmmoType, int>


[Factory]
_def = class
machines = map<Position, Machine>
c_mixture_formulas = map<AmmoType, map<MaterialType, int>>
c_construction_durations = map<AmmoType, int>
c_ammo_box_sizes = map<AmmoType, int>


##############################################################

[Agent]
_def = class
type = AgentType
position = Position
materials_bag = map<MaterialType, int>
c_materials_bag_capacity = int
ammos_bag = map<AmmoType, int>
c_ammos_bag_capacity = int


[Unit]
_def = class
type = UnitType
health = int
c_individual_health = int
c_individual_damage = int
c_damage_distribution = map<UnitType, float>
ammo_count = int
reload_rem_time = int
c_reload_duration = int


[Base]
_def = class
c_area = list<ECell>
agents = map<AgentType, Agent>
frontline_delivery = FrontlineDelivery
repository = Repository
backline_delivery = BacklineDelivery
factory = Factory
units = map<UnitType, Unit>


##############################################################

[World]
_def = class
max_cycles = int
bases = map<string, Base>
total_healths = map<string, int>
