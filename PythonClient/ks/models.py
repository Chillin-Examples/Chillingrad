# -*- coding: utf-8 -*-

# python imports
import sys
import struct
from enum import Enum

PY3 = sys.version_info > (3,)


class ECell(Enum):
	Empty = 0
	FrontlineDelivery = 1
	Material = 2
	BacklineDelivery = 3
	Machine = 4


class MachineStatus(Enum):
	Idle = 0
	Working = 1
	AmmoReady = 2


class MaterialType(Enum):
	Powder = 0
	Steel = 1
	Aluminum = 2
	Shell = 3
	Nickel = 4
	Manganese = 5
	Chromium = 6


class AmmoType(Enum):
	RifleBullet = 0
	TankShell = 1
	Bomb = 2
	ArtilleryShell = 3
	HMGBullet = 4


class UnitType(Enum):
	Soldier = 0
	Tank = 1
	Aircraft = 2
	Artillery = 3
	HeavyMachineGunner = 4


class AgentType(Enum):
	Warehouse = 0
	Factory = 1


class Position(object):

	@staticmethod
	def name():
		return 'Position'


	def __init__(self, index=None):
		self.initialize(index)
	

	def initialize(self, index=None):
		self.index = index
	

	def serialize(self):
		s = b''
		
		# serialize self.index
		s += b'\x00' if self.index is None else b'\x01'
		if self.index is not None:
			s += struct.pack('i', self.index)
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize self.index
		tmp0 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp0:
			self.index = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.index = None
		
		return offset


class Material(object):

	@staticmethod
	def name():
		return 'Material'


	def __init__(self, type=None, position=None, count=None, c_capacity=None):
		self.initialize(type, position, count, c_capacity)
	

	def initialize(self, type=None, position=None, count=None, c_capacity=None):
		self.type = type
		self.position = position
		self.count = count
		self.c_capacity = c_capacity
	

	def serialize(self):
		s = b''
		
		# serialize self.type
		s += b'\x00' if self.type is None else b'\x01'
		if self.type is not None:
			s += struct.pack('b', self.type.value)
		
		# serialize self.position
		s += b'\x00' if self.position is None else b'\x01'
		if self.position is not None:
			s += self.position.serialize()
		
		# serialize self.count
		s += b'\x00' if self.count is None else b'\x01'
		if self.count is not None:
			s += struct.pack('i', self.count)
		
		# serialize self.c_capacity
		s += b'\x00' if self.c_capacity is None else b'\x01'
		if self.c_capacity is not None:
			s += struct.pack('i', self.c_capacity)
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize self.type
		tmp1 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp1:
			tmp2 = struct.unpack('b', s[offset:offset + 1])[0]
			offset += 1
			self.type = MaterialType(tmp2)
		else:
			self.type = None
		
		# deserialize self.position
		tmp3 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp3:
			self.position = Position()
			offset = self.position.deserialize(s, offset)
		else:
			self.position = None
		
		# deserialize self.count
		tmp4 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp4:
			self.count = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.count = None
		
		# deserialize self.c_capacity
		tmp5 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp5:
			self.c_capacity = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.c_capacity = None
		
		return offset


class Machine(object):

	@staticmethod
	def name():
		return 'Machine'


	def __init__(self, status=None, position=None, current_ammo=None, construction_rem_time=None):
		self.initialize(status, position, current_ammo, construction_rem_time)
	

	def initialize(self, status=None, position=None, current_ammo=None, construction_rem_time=None):
		self.status = status
		self.position = position
		self.current_ammo = current_ammo
		self.construction_rem_time = construction_rem_time
	

	def serialize(self):
		s = b''
		
		# serialize self.status
		s += b'\x00' if self.status is None else b'\x01'
		if self.status is not None:
			s += struct.pack('b', self.status.value)
		
		# serialize self.position
		s += b'\x00' if self.position is None else b'\x01'
		if self.position is not None:
			s += self.position.serialize()
		
		# serialize self.current_ammo
		s += b'\x00' if self.current_ammo is None else b'\x01'
		if self.current_ammo is not None:
			s += struct.pack('b', self.current_ammo.value)
		
		# serialize self.construction_rem_time
		s += b'\x00' if self.construction_rem_time is None else b'\x01'
		if self.construction_rem_time is not None:
			s += struct.pack('i', self.construction_rem_time)
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize self.status
		tmp6 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp6:
			tmp7 = struct.unpack('b', s[offset:offset + 1])[0]
			offset += 1
			self.status = MachineStatus(tmp7)
		else:
			self.status = None
		
		# deserialize self.position
		tmp8 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp8:
			self.position = Position()
			offset = self.position.deserialize(s, offset)
		else:
			self.position = None
		
		# deserialize self.current_ammo
		tmp9 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp9:
			tmp10 = struct.unpack('b', s[offset:offset + 1])[0]
			offset += 1
			self.current_ammo = AmmoType(tmp10)
		else:
			self.current_ammo = None
		
		# deserialize self.construction_rem_time
		tmp11 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp11:
			self.construction_rem_time = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.construction_rem_time = None
		
		return offset


class FrontlineDelivery(object):

	@staticmethod
	def name():
		return 'FrontlineDelivery'


	def __init__(self, is_available=None, ammos=None, truck_delivery_rem_time=None, c_truck_delivery_duration=None, truck_return_rem_time=None, c_truck_return_duration=None):
		self.initialize(is_available, ammos, truck_delivery_rem_time, c_truck_delivery_duration, truck_return_rem_time, c_truck_return_duration)
	

	def initialize(self, is_available=None, ammos=None, truck_delivery_rem_time=None, c_truck_delivery_duration=None, truck_return_rem_time=None, c_truck_return_duration=None):
		self.is_available = is_available
		self.ammos = ammos
		self.truck_delivery_rem_time = truck_delivery_rem_time
		self.c_truck_delivery_duration = c_truck_delivery_duration
		self.truck_return_rem_time = truck_return_rem_time
		self.c_truck_return_duration = c_truck_return_duration
	

	def serialize(self):
		s = b''
		
		# serialize self.is_available
		s += b'\x00' if self.is_available is None else b'\x01'
		if self.is_available is not None:
			s += struct.pack('?', self.is_available)
		
		# serialize self.ammos
		s += b'\x00' if self.ammos is None else b'\x01'
		if self.ammos is not None:
			tmp12 = b''
			tmp12 += struct.pack('I', len(self.ammos))
			while len(tmp12) and tmp12[-1] == b'\x00'[0]:
				tmp12 = tmp12[:-1]
			s += struct.pack('B', len(tmp12))
			s += tmp12
			
			for tmp13 in self.ammos:
				s += b'\x00' if tmp13 is None else b'\x01'
				if tmp13 is not None:
					s += struct.pack('b', tmp13.value)
				s += b'\x00' if self.ammos[tmp13] is None else b'\x01'
				if self.ammos[tmp13] is not None:
					s += struct.pack('i', self.ammos[tmp13])
		
		# serialize self.truck_delivery_rem_time
		s += b'\x00' if self.truck_delivery_rem_time is None else b'\x01'
		if self.truck_delivery_rem_time is not None:
			s += struct.pack('i', self.truck_delivery_rem_time)
		
		# serialize self.c_truck_delivery_duration
		s += b'\x00' if self.c_truck_delivery_duration is None else b'\x01'
		if self.c_truck_delivery_duration is not None:
			s += struct.pack('i', self.c_truck_delivery_duration)
		
		# serialize self.truck_return_rem_time
		s += b'\x00' if self.truck_return_rem_time is None else b'\x01'
		if self.truck_return_rem_time is not None:
			s += struct.pack('i', self.truck_return_rem_time)
		
		# serialize self.c_truck_return_duration
		s += b'\x00' if self.c_truck_return_duration is None else b'\x01'
		if self.c_truck_return_duration is not None:
			s += struct.pack('i', self.c_truck_return_duration)
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize self.is_available
		tmp14 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp14:
			self.is_available = struct.unpack('?', s[offset:offset + 1])[0]
			offset += 1
		else:
			self.is_available = None
		
		# deserialize self.ammos
		tmp15 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp15:
			tmp16 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp17 = s[offset:offset + tmp16]
			offset += tmp16
			tmp17 += b'\x00' * (4 - tmp16)
			tmp18 = struct.unpack('I', tmp17)[0]
			
			self.ammos = {}
			for tmp19 in range(tmp18):
				tmp22 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp22:
					tmp23 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp20 = AmmoType(tmp23)
				else:
					tmp20 = None
				tmp24 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp24:
					tmp21 = struct.unpack('i', s[offset:offset + 4])[0]
					offset += 4
				else:
					tmp21 = None
				self.ammos[tmp20] = tmp21
		else:
			self.ammos = None
		
		# deserialize self.truck_delivery_rem_time
		tmp25 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp25:
			self.truck_delivery_rem_time = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.truck_delivery_rem_time = None
		
		# deserialize self.c_truck_delivery_duration
		tmp26 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp26:
			self.c_truck_delivery_duration = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.c_truck_delivery_duration = None
		
		# deserialize self.truck_return_rem_time
		tmp27 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp27:
			self.truck_return_rem_time = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.truck_return_rem_time = None
		
		# deserialize self.c_truck_return_duration
		tmp28 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp28:
			self.c_truck_return_duration = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.c_truck_return_duration = None
		
		return offset


class Warehouse(object):

	@staticmethod
	def name():
		return 'Warehouse'


	def __init__(self, materials=None, materials_reload_rem_time=None, c_materials_reload_duration=None):
		self.initialize(materials, materials_reload_rem_time, c_materials_reload_duration)
	

	def initialize(self, materials=None, materials_reload_rem_time=None, c_materials_reload_duration=None):
		self.materials = materials
		self.materials_reload_rem_time = materials_reload_rem_time
		self.c_materials_reload_duration = c_materials_reload_duration
	

	def serialize(self):
		s = b''
		
		# serialize self.materials
		s += b'\x00' if self.materials is None else b'\x01'
		if self.materials is not None:
			tmp29 = b''
			tmp29 += struct.pack('I', len(self.materials))
			while len(tmp29) and tmp29[-1] == b'\x00'[0]:
				tmp29 = tmp29[:-1]
			s += struct.pack('B', len(tmp29))
			s += tmp29
			
			for tmp30 in self.materials:
				s += b'\x00' if tmp30 is None else b'\x01'
				if tmp30 is not None:
					s += tmp30.serialize()
				s += b'\x00' if self.materials[tmp30] is None else b'\x01'
				if self.materials[tmp30] is not None:
					s += self.materials[tmp30].serialize()
		
		# serialize self.materials_reload_rem_time
		s += b'\x00' if self.materials_reload_rem_time is None else b'\x01'
		if self.materials_reload_rem_time is not None:
			s += struct.pack('i', self.materials_reload_rem_time)
		
		# serialize self.c_materials_reload_duration
		s += b'\x00' if self.c_materials_reload_duration is None else b'\x01'
		if self.c_materials_reload_duration is not None:
			s += struct.pack('i', self.c_materials_reload_duration)
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize self.materials
		tmp31 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp31:
			tmp32 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp33 = s[offset:offset + tmp32]
			offset += tmp32
			tmp33 += b'\x00' * (4 - tmp32)
			tmp34 = struct.unpack('I', tmp33)[0]
			
			self.materials = {}
			for tmp35 in range(tmp34):
				tmp38 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp38:
					tmp36 = Position()
					offset = tmp36.deserialize(s, offset)
				else:
					tmp36 = None
				tmp39 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp39:
					tmp37 = Material()
					offset = tmp37.deserialize(s, offset)
				else:
					tmp37 = None
				self.materials[tmp36] = tmp37
		else:
			self.materials = None
		
		# deserialize self.materials_reload_rem_time
		tmp40 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp40:
			self.materials_reload_rem_time = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.materials_reload_rem_time = None
		
		# deserialize self.c_materials_reload_duration
		tmp41 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp41:
			self.c_materials_reload_duration = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.c_materials_reload_duration = None
		
		return offset


class BacklineDelivery(object):

	@staticmethod
	def name():
		return 'BacklineDelivery'


	def __init__(self, materials=None, ammos=None):
		self.initialize(materials, ammos)
	

	def initialize(self, materials=None, ammos=None):
		self.materials = materials
		self.ammos = ammos
	

	def serialize(self):
		s = b''
		
		# serialize self.materials
		s += b'\x00' if self.materials is None else b'\x01'
		if self.materials is not None:
			tmp42 = b''
			tmp42 += struct.pack('I', len(self.materials))
			while len(tmp42) and tmp42[-1] == b'\x00'[0]:
				tmp42 = tmp42[:-1]
			s += struct.pack('B', len(tmp42))
			s += tmp42
			
			for tmp43 in self.materials:
				s += b'\x00' if tmp43 is None else b'\x01'
				if tmp43 is not None:
					s += struct.pack('b', tmp43.value)
				s += b'\x00' if self.materials[tmp43] is None else b'\x01'
				if self.materials[tmp43] is not None:
					s += struct.pack('i', self.materials[tmp43])
		
		# serialize self.ammos
		s += b'\x00' if self.ammos is None else b'\x01'
		if self.ammos is not None:
			tmp44 = b''
			tmp44 += struct.pack('I', len(self.ammos))
			while len(tmp44) and tmp44[-1] == b'\x00'[0]:
				tmp44 = tmp44[:-1]
			s += struct.pack('B', len(tmp44))
			s += tmp44
			
			for tmp45 in self.ammos:
				s += b'\x00' if tmp45 is None else b'\x01'
				if tmp45 is not None:
					s += struct.pack('b', tmp45.value)
				s += b'\x00' if self.ammos[tmp45] is None else b'\x01'
				if self.ammos[tmp45] is not None:
					s += struct.pack('i', self.ammos[tmp45])
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize self.materials
		tmp46 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp46:
			tmp47 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp48 = s[offset:offset + tmp47]
			offset += tmp47
			tmp48 += b'\x00' * (4 - tmp47)
			tmp49 = struct.unpack('I', tmp48)[0]
			
			self.materials = {}
			for tmp50 in range(tmp49):
				tmp53 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp53:
					tmp54 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp51 = MaterialType(tmp54)
				else:
					tmp51 = None
				tmp55 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp55:
					tmp52 = struct.unpack('i', s[offset:offset + 4])[0]
					offset += 4
				else:
					tmp52 = None
				self.materials[tmp51] = tmp52
		else:
			self.materials = None
		
		# deserialize self.ammos
		tmp56 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp56:
			tmp57 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp58 = s[offset:offset + tmp57]
			offset += tmp57
			tmp58 += b'\x00' * (4 - tmp57)
			tmp59 = struct.unpack('I', tmp58)[0]
			
			self.ammos = {}
			for tmp60 in range(tmp59):
				tmp63 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp63:
					tmp64 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp61 = AmmoType(tmp64)
				else:
					tmp61 = None
				tmp65 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp65:
					tmp62 = struct.unpack('i', s[offset:offset + 4])[0]
					offset += 4
				else:
					tmp62 = None
				self.ammos[tmp61] = tmp62
		else:
			self.ammos = None
		
		return offset


class Factory(object):

	@staticmethod
	def name():
		return 'Factory'


	def __init__(self, machines=None, c_mixture_formulas=None, c_construction_durations=None, c_ammo_box_sizes=None):
		self.initialize(machines, c_mixture_formulas, c_construction_durations, c_ammo_box_sizes)
	

	def initialize(self, machines=None, c_mixture_formulas=None, c_construction_durations=None, c_ammo_box_sizes=None):
		self.machines = machines
		self.c_mixture_formulas = c_mixture_formulas
		self.c_construction_durations = c_construction_durations
		self.c_ammo_box_sizes = c_ammo_box_sizes
	

	def serialize(self):
		s = b''
		
		# serialize self.machines
		s += b'\x00' if self.machines is None else b'\x01'
		if self.machines is not None:
			tmp66 = b''
			tmp66 += struct.pack('I', len(self.machines))
			while len(tmp66) and tmp66[-1] == b'\x00'[0]:
				tmp66 = tmp66[:-1]
			s += struct.pack('B', len(tmp66))
			s += tmp66
			
			for tmp67 in self.machines:
				s += b'\x00' if tmp67 is None else b'\x01'
				if tmp67 is not None:
					s += tmp67.serialize()
				s += b'\x00' if self.machines[tmp67] is None else b'\x01'
				if self.machines[tmp67] is not None:
					s += self.machines[tmp67].serialize()
		
		# serialize self.c_mixture_formulas
		s += b'\x00' if self.c_mixture_formulas is None else b'\x01'
		if self.c_mixture_formulas is not None:
			tmp68 = b''
			tmp68 += struct.pack('I', len(self.c_mixture_formulas))
			while len(tmp68) and tmp68[-1] == b'\x00'[0]:
				tmp68 = tmp68[:-1]
			s += struct.pack('B', len(tmp68))
			s += tmp68
			
			for tmp69 in self.c_mixture_formulas:
				s += b'\x00' if tmp69 is None else b'\x01'
				if tmp69 is not None:
					s += struct.pack('b', tmp69.value)
				s += b'\x00' if self.c_mixture_formulas[tmp69] is None else b'\x01'
				if self.c_mixture_formulas[tmp69] is not None:
					tmp70 = b''
					tmp70 += struct.pack('I', len(self.c_mixture_formulas[tmp69]))
					while len(tmp70) and tmp70[-1] == b'\x00'[0]:
						tmp70 = tmp70[:-1]
					s += struct.pack('B', len(tmp70))
					s += tmp70
					
					for tmp71 in self.c_mixture_formulas[tmp69]:
						s += b'\x00' if tmp71 is None else b'\x01'
						if tmp71 is not None:
							s += struct.pack('b', tmp71.value)
						s += b'\x00' if self.c_mixture_formulas[tmp69][tmp71] is None else b'\x01'
						if self.c_mixture_formulas[tmp69][tmp71] is not None:
							s += struct.pack('i', self.c_mixture_formulas[tmp69][tmp71])
		
		# serialize self.c_construction_durations
		s += b'\x00' if self.c_construction_durations is None else b'\x01'
		if self.c_construction_durations is not None:
			tmp72 = b''
			tmp72 += struct.pack('I', len(self.c_construction_durations))
			while len(tmp72) and tmp72[-1] == b'\x00'[0]:
				tmp72 = tmp72[:-1]
			s += struct.pack('B', len(tmp72))
			s += tmp72
			
			for tmp73 in self.c_construction_durations:
				s += b'\x00' if tmp73 is None else b'\x01'
				if tmp73 is not None:
					s += struct.pack('b', tmp73.value)
				s += b'\x00' if self.c_construction_durations[tmp73] is None else b'\x01'
				if self.c_construction_durations[tmp73] is not None:
					s += struct.pack('i', self.c_construction_durations[tmp73])
		
		# serialize self.c_ammo_box_sizes
		s += b'\x00' if self.c_ammo_box_sizes is None else b'\x01'
		if self.c_ammo_box_sizes is not None:
			tmp74 = b''
			tmp74 += struct.pack('I', len(self.c_ammo_box_sizes))
			while len(tmp74) and tmp74[-1] == b'\x00'[0]:
				tmp74 = tmp74[:-1]
			s += struct.pack('B', len(tmp74))
			s += tmp74
			
			for tmp75 in self.c_ammo_box_sizes:
				s += b'\x00' if tmp75 is None else b'\x01'
				if tmp75 is not None:
					s += struct.pack('b', tmp75.value)
				s += b'\x00' if self.c_ammo_box_sizes[tmp75] is None else b'\x01'
				if self.c_ammo_box_sizes[tmp75] is not None:
					s += struct.pack('i', self.c_ammo_box_sizes[tmp75])
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize self.machines
		tmp76 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp76:
			tmp77 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp78 = s[offset:offset + tmp77]
			offset += tmp77
			tmp78 += b'\x00' * (4 - tmp77)
			tmp79 = struct.unpack('I', tmp78)[0]
			
			self.machines = {}
			for tmp80 in range(tmp79):
				tmp83 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp83:
					tmp81 = Position()
					offset = tmp81.deserialize(s, offset)
				else:
					tmp81 = None
				tmp84 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp84:
					tmp82 = Machine()
					offset = tmp82.deserialize(s, offset)
				else:
					tmp82 = None
				self.machines[tmp81] = tmp82
		else:
			self.machines = None
		
		# deserialize self.c_mixture_formulas
		tmp85 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp85:
			tmp86 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp87 = s[offset:offset + tmp86]
			offset += tmp86
			tmp87 += b'\x00' * (4 - tmp86)
			tmp88 = struct.unpack('I', tmp87)[0]
			
			self.c_mixture_formulas = {}
			for tmp89 in range(tmp88):
				tmp92 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp92:
					tmp93 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp90 = AmmoType(tmp93)
				else:
					tmp90 = None
				tmp94 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp94:
					tmp95 = struct.unpack('B', s[offset:offset + 1])[0]
					offset += 1
					tmp96 = s[offset:offset + tmp95]
					offset += tmp95
					tmp96 += b'\x00' * (4 - tmp95)
					tmp97 = struct.unpack('I', tmp96)[0]
					
					tmp91 = {}
					for tmp98 in range(tmp97):
						tmp101 = struct.unpack('B', s[offset:offset + 1])[0]
						offset += 1
						if tmp101:
							tmp102 = struct.unpack('b', s[offset:offset + 1])[0]
							offset += 1
							tmp99 = MaterialType(tmp102)
						else:
							tmp99 = None
						tmp103 = struct.unpack('B', s[offset:offset + 1])[0]
						offset += 1
						if tmp103:
							tmp100 = struct.unpack('i', s[offset:offset + 4])[0]
							offset += 4
						else:
							tmp100 = None
						tmp91[tmp99] = tmp100
				else:
					tmp91 = None
				self.c_mixture_formulas[tmp90] = tmp91
		else:
			self.c_mixture_formulas = None
		
		# deserialize self.c_construction_durations
		tmp104 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp104:
			tmp105 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp106 = s[offset:offset + tmp105]
			offset += tmp105
			tmp106 += b'\x00' * (4 - tmp105)
			tmp107 = struct.unpack('I', tmp106)[0]
			
			self.c_construction_durations = {}
			for tmp108 in range(tmp107):
				tmp111 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp111:
					tmp112 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp109 = AmmoType(tmp112)
				else:
					tmp109 = None
				tmp113 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp113:
					tmp110 = struct.unpack('i', s[offset:offset + 4])[0]
					offset += 4
				else:
					tmp110 = None
				self.c_construction_durations[tmp109] = tmp110
		else:
			self.c_construction_durations = None
		
		# deserialize self.c_ammo_box_sizes
		tmp114 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp114:
			tmp115 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp116 = s[offset:offset + tmp115]
			offset += tmp115
			tmp116 += b'\x00' * (4 - tmp115)
			tmp117 = struct.unpack('I', tmp116)[0]
			
			self.c_ammo_box_sizes = {}
			for tmp118 in range(tmp117):
				tmp121 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp121:
					tmp122 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp119 = AmmoType(tmp122)
				else:
					tmp119 = None
				tmp123 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp123:
					tmp120 = struct.unpack('i', s[offset:offset + 4])[0]
					offset += 4
				else:
					tmp120 = None
				self.c_ammo_box_sizes[tmp119] = tmp120
		else:
			self.c_ammo_box_sizes = None
		
		return offset


class Agent(object):

	@staticmethod
	def name():
		return 'Agent'


	def __init__(self, type=None, position=None, materials_bag=None, c_materials_bag_capacity=None, ammos_bag=None, c_ammos_bag_capacity=None):
		self.initialize(type, position, materials_bag, c_materials_bag_capacity, ammos_bag, c_ammos_bag_capacity)
	

	def initialize(self, type=None, position=None, materials_bag=None, c_materials_bag_capacity=None, ammos_bag=None, c_ammos_bag_capacity=None):
		self.type = type
		self.position = position
		self.materials_bag = materials_bag
		self.c_materials_bag_capacity = c_materials_bag_capacity
		self.ammos_bag = ammos_bag
		self.c_ammos_bag_capacity = c_ammos_bag_capacity
	

	def serialize(self):
		s = b''
		
		# serialize self.type
		s += b'\x00' if self.type is None else b'\x01'
		if self.type is not None:
			s += struct.pack('b', self.type.value)
		
		# serialize self.position
		s += b'\x00' if self.position is None else b'\x01'
		if self.position is not None:
			s += self.position.serialize()
		
		# serialize self.materials_bag
		s += b'\x00' if self.materials_bag is None else b'\x01'
		if self.materials_bag is not None:
			tmp124 = b''
			tmp124 += struct.pack('I', len(self.materials_bag))
			while len(tmp124) and tmp124[-1] == b'\x00'[0]:
				tmp124 = tmp124[:-1]
			s += struct.pack('B', len(tmp124))
			s += tmp124
			
			for tmp125 in self.materials_bag:
				s += b'\x00' if tmp125 is None else b'\x01'
				if tmp125 is not None:
					s += struct.pack('b', tmp125.value)
				s += b'\x00' if self.materials_bag[tmp125] is None else b'\x01'
				if self.materials_bag[tmp125] is not None:
					s += struct.pack('i', self.materials_bag[tmp125])
		
		# serialize self.c_materials_bag_capacity
		s += b'\x00' if self.c_materials_bag_capacity is None else b'\x01'
		if self.c_materials_bag_capacity is not None:
			s += struct.pack('i', self.c_materials_bag_capacity)
		
		# serialize self.ammos_bag
		s += b'\x00' if self.ammos_bag is None else b'\x01'
		if self.ammos_bag is not None:
			tmp126 = b''
			tmp126 += struct.pack('I', len(self.ammos_bag))
			while len(tmp126) and tmp126[-1] == b'\x00'[0]:
				tmp126 = tmp126[:-1]
			s += struct.pack('B', len(tmp126))
			s += tmp126
			
			for tmp127 in self.ammos_bag:
				s += b'\x00' if tmp127 is None else b'\x01'
				if tmp127 is not None:
					s += struct.pack('b', tmp127.value)
				s += b'\x00' if self.ammos_bag[tmp127] is None else b'\x01'
				if self.ammos_bag[tmp127] is not None:
					s += struct.pack('i', self.ammos_bag[tmp127])
		
		# serialize self.c_ammos_bag_capacity
		s += b'\x00' if self.c_ammos_bag_capacity is None else b'\x01'
		if self.c_ammos_bag_capacity is not None:
			s += struct.pack('i', self.c_ammos_bag_capacity)
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize self.type
		tmp128 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp128:
			tmp129 = struct.unpack('b', s[offset:offset + 1])[0]
			offset += 1
			self.type = AgentType(tmp129)
		else:
			self.type = None
		
		# deserialize self.position
		tmp130 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp130:
			self.position = Position()
			offset = self.position.deserialize(s, offset)
		else:
			self.position = None
		
		# deserialize self.materials_bag
		tmp131 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp131:
			tmp132 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp133 = s[offset:offset + tmp132]
			offset += tmp132
			tmp133 += b'\x00' * (4 - tmp132)
			tmp134 = struct.unpack('I', tmp133)[0]
			
			self.materials_bag = {}
			for tmp135 in range(tmp134):
				tmp138 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp138:
					tmp139 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp136 = MaterialType(tmp139)
				else:
					tmp136 = None
				tmp140 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp140:
					tmp137 = struct.unpack('i', s[offset:offset + 4])[0]
					offset += 4
				else:
					tmp137 = None
				self.materials_bag[tmp136] = tmp137
		else:
			self.materials_bag = None
		
		# deserialize self.c_materials_bag_capacity
		tmp141 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp141:
			self.c_materials_bag_capacity = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.c_materials_bag_capacity = None
		
		# deserialize self.ammos_bag
		tmp142 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp142:
			tmp143 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp144 = s[offset:offset + tmp143]
			offset += tmp143
			tmp144 += b'\x00' * (4 - tmp143)
			tmp145 = struct.unpack('I', tmp144)[0]
			
			self.ammos_bag = {}
			for tmp146 in range(tmp145):
				tmp149 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp149:
					tmp150 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp147 = AmmoType(tmp150)
				else:
					tmp147 = None
				tmp151 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp151:
					tmp148 = struct.unpack('i', s[offset:offset + 4])[0]
					offset += 4
				else:
					tmp148 = None
				self.ammos_bag[tmp147] = tmp148
		else:
			self.ammos_bag = None
		
		# deserialize self.c_ammos_bag_capacity
		tmp152 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp152:
			self.c_ammos_bag_capacity = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.c_ammos_bag_capacity = None
		
		return offset


class Unit(object):

	@staticmethod
	def name():
		return 'Unit'


	def __init__(self, type=None, health=None, c_individual_health=None, c_individual_damage=None, c_damage_distribution=None, ammo_count=None, reload_rem_time=None, c_reload_duration=None):
		self.initialize(type, health, c_individual_health, c_individual_damage, c_damage_distribution, ammo_count, reload_rem_time, c_reload_duration)
	

	def initialize(self, type=None, health=None, c_individual_health=None, c_individual_damage=None, c_damage_distribution=None, ammo_count=None, reload_rem_time=None, c_reload_duration=None):
		self.type = type
		self.health = health
		self.c_individual_health = c_individual_health
		self.c_individual_damage = c_individual_damage
		self.c_damage_distribution = c_damage_distribution
		self.ammo_count = ammo_count
		self.reload_rem_time = reload_rem_time
		self.c_reload_duration = c_reload_duration
	

	def serialize(self):
		s = b''
		
		# serialize self.type
		s += b'\x00' if self.type is None else b'\x01'
		if self.type is not None:
			s += struct.pack('b', self.type.value)
		
		# serialize self.health
		s += b'\x00' if self.health is None else b'\x01'
		if self.health is not None:
			s += struct.pack('i', self.health)
		
		# serialize self.c_individual_health
		s += b'\x00' if self.c_individual_health is None else b'\x01'
		if self.c_individual_health is not None:
			s += struct.pack('i', self.c_individual_health)
		
		# serialize self.c_individual_damage
		s += b'\x00' if self.c_individual_damage is None else b'\x01'
		if self.c_individual_damage is not None:
			s += struct.pack('i', self.c_individual_damage)
		
		# serialize self.c_damage_distribution
		s += b'\x00' if self.c_damage_distribution is None else b'\x01'
		if self.c_damage_distribution is not None:
			tmp153 = b''
			tmp153 += struct.pack('I', len(self.c_damage_distribution))
			while len(tmp153) and tmp153[-1] == b'\x00'[0]:
				tmp153 = tmp153[:-1]
			s += struct.pack('B', len(tmp153))
			s += tmp153
			
			for tmp154 in self.c_damage_distribution:
				s += b'\x00' if tmp154 is None else b'\x01'
				if tmp154 is not None:
					s += struct.pack('b', tmp154.value)
				s += b'\x00' if self.c_damage_distribution[tmp154] is None else b'\x01'
				if self.c_damage_distribution[tmp154] is not None:
					s += struct.pack('f', self.c_damage_distribution[tmp154])
		
		# serialize self.ammo_count
		s += b'\x00' if self.ammo_count is None else b'\x01'
		if self.ammo_count is not None:
			s += struct.pack('i', self.ammo_count)
		
		# serialize self.reload_rem_time
		s += b'\x00' if self.reload_rem_time is None else b'\x01'
		if self.reload_rem_time is not None:
			s += struct.pack('i', self.reload_rem_time)
		
		# serialize self.c_reload_duration
		s += b'\x00' if self.c_reload_duration is None else b'\x01'
		if self.c_reload_duration is not None:
			s += struct.pack('i', self.c_reload_duration)
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize self.type
		tmp155 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp155:
			tmp156 = struct.unpack('b', s[offset:offset + 1])[0]
			offset += 1
			self.type = UnitType(tmp156)
		else:
			self.type = None
		
		# deserialize self.health
		tmp157 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp157:
			self.health = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.health = None
		
		# deserialize self.c_individual_health
		tmp158 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp158:
			self.c_individual_health = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.c_individual_health = None
		
		# deserialize self.c_individual_damage
		tmp159 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp159:
			self.c_individual_damage = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.c_individual_damage = None
		
		# deserialize self.c_damage_distribution
		tmp160 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp160:
			tmp161 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp162 = s[offset:offset + tmp161]
			offset += tmp161
			tmp162 += b'\x00' * (4 - tmp161)
			tmp163 = struct.unpack('I', tmp162)[0]
			
			self.c_damage_distribution = {}
			for tmp164 in range(tmp163):
				tmp167 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp167:
					tmp168 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp165 = UnitType(tmp168)
				else:
					tmp165 = None
				tmp169 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp169:
					tmp166 = struct.unpack('f', s[offset:offset + 4])[0]
					offset += 4
				else:
					tmp166 = None
				self.c_damage_distribution[tmp165] = tmp166
		else:
			self.c_damage_distribution = None
		
		# deserialize self.ammo_count
		tmp170 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp170:
			self.ammo_count = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.ammo_count = None
		
		# deserialize self.reload_rem_time
		tmp171 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp171:
			self.reload_rem_time = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.reload_rem_time = None
		
		# deserialize self.c_reload_duration
		tmp172 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp172:
			self.c_reload_duration = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.c_reload_duration = None
		
		return offset


class Base(object):

	@staticmethod
	def name():
		return 'Base'


	def __init__(self, c_area=None, agents=None, frontline_delivery=None, warehouse=None, backline_delivery=None, factory=None, units=None):
		self.initialize(c_area, agents, frontline_delivery, warehouse, backline_delivery, factory, units)
	

	def initialize(self, c_area=None, agents=None, frontline_delivery=None, warehouse=None, backline_delivery=None, factory=None, units=None):
		self.c_area = c_area
		self.agents = agents
		self.frontline_delivery = frontline_delivery
		self.warehouse = warehouse
		self.backline_delivery = backline_delivery
		self.factory = factory
		self.units = units
	

	def serialize(self):
		s = b''
		
		# serialize self.c_area
		s += b'\x00' if self.c_area is None else b'\x01'
		if self.c_area is not None:
			tmp173 = b''
			tmp173 += struct.pack('I', len(self.c_area))
			while len(tmp173) and tmp173[-1] == b'\x00'[0]:
				tmp173 = tmp173[:-1]
			s += struct.pack('B', len(tmp173))
			s += tmp173
			
			for tmp174 in self.c_area:
				s += b'\x00' if tmp174 is None else b'\x01'
				if tmp174 is not None:
					s += struct.pack('b', tmp174.value)
		
		# serialize self.agents
		s += b'\x00' if self.agents is None else b'\x01'
		if self.agents is not None:
			tmp175 = b''
			tmp175 += struct.pack('I', len(self.agents))
			while len(tmp175) and tmp175[-1] == b'\x00'[0]:
				tmp175 = tmp175[:-1]
			s += struct.pack('B', len(tmp175))
			s += tmp175
			
			for tmp176 in self.agents:
				s += b'\x00' if tmp176 is None else b'\x01'
				if tmp176 is not None:
					s += struct.pack('b', tmp176.value)
				s += b'\x00' if self.agents[tmp176] is None else b'\x01'
				if self.agents[tmp176] is not None:
					s += self.agents[tmp176].serialize()
		
		# serialize self.frontline_delivery
		s += b'\x00' if self.frontline_delivery is None else b'\x01'
		if self.frontline_delivery is not None:
			s += self.frontline_delivery.serialize()
		
		# serialize self.warehouse
		s += b'\x00' if self.warehouse is None else b'\x01'
		if self.warehouse is not None:
			s += self.warehouse.serialize()
		
		# serialize self.backline_delivery
		s += b'\x00' if self.backline_delivery is None else b'\x01'
		if self.backline_delivery is not None:
			s += self.backline_delivery.serialize()
		
		# serialize self.factory
		s += b'\x00' if self.factory is None else b'\x01'
		if self.factory is not None:
			s += self.factory.serialize()
		
		# serialize self.units
		s += b'\x00' if self.units is None else b'\x01'
		if self.units is not None:
			tmp177 = b''
			tmp177 += struct.pack('I', len(self.units))
			while len(tmp177) and tmp177[-1] == b'\x00'[0]:
				tmp177 = tmp177[:-1]
			s += struct.pack('B', len(tmp177))
			s += tmp177
			
			for tmp178 in self.units:
				s += b'\x00' if tmp178 is None else b'\x01'
				if tmp178 is not None:
					s += struct.pack('b', tmp178.value)
				s += b'\x00' if self.units[tmp178] is None else b'\x01'
				if self.units[tmp178] is not None:
					s += self.units[tmp178].serialize()
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize self.c_area
		tmp179 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp179:
			tmp180 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp181 = s[offset:offset + tmp180]
			offset += tmp180
			tmp181 += b'\x00' * (4 - tmp180)
			tmp182 = struct.unpack('I', tmp181)[0]
			
			self.c_area = []
			for tmp183 in range(tmp182):
				tmp185 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp185:
					tmp186 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp184 = ECell(tmp186)
				else:
					tmp184 = None
				self.c_area.append(tmp184)
		else:
			self.c_area = None
		
		# deserialize self.agents
		tmp187 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp187:
			tmp188 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp189 = s[offset:offset + tmp188]
			offset += tmp188
			tmp189 += b'\x00' * (4 - tmp188)
			tmp190 = struct.unpack('I', tmp189)[0]
			
			self.agents = {}
			for tmp191 in range(tmp190):
				tmp194 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp194:
					tmp195 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp192 = AgentType(tmp195)
				else:
					tmp192 = None
				tmp196 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp196:
					tmp193 = Agent()
					offset = tmp193.deserialize(s, offset)
				else:
					tmp193 = None
				self.agents[tmp192] = tmp193
		else:
			self.agents = None
		
		# deserialize self.frontline_delivery
		tmp197 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp197:
			self.frontline_delivery = FrontlineDelivery()
			offset = self.frontline_delivery.deserialize(s, offset)
		else:
			self.frontline_delivery = None
		
		# deserialize self.warehouse
		tmp198 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp198:
			self.warehouse = Warehouse()
			offset = self.warehouse.deserialize(s, offset)
		else:
			self.warehouse = None
		
		# deserialize self.backline_delivery
		tmp199 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp199:
			self.backline_delivery = BacklineDelivery()
			offset = self.backline_delivery.deserialize(s, offset)
		else:
			self.backline_delivery = None
		
		# deserialize self.factory
		tmp200 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp200:
			self.factory = Factory()
			offset = self.factory.deserialize(s, offset)
		else:
			self.factory = None
		
		# deserialize self.units
		tmp201 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp201:
			tmp202 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp203 = s[offset:offset + tmp202]
			offset += tmp202
			tmp203 += b'\x00' * (4 - tmp202)
			tmp204 = struct.unpack('I', tmp203)[0]
			
			self.units = {}
			for tmp205 in range(tmp204):
				tmp208 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp208:
					tmp209 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp206 = UnitType(tmp209)
				else:
					tmp206 = None
				tmp210 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp210:
					tmp207 = Unit()
					offset = tmp207.deserialize(s, offset)
				else:
					tmp207 = None
				self.units[tmp206] = tmp207
		else:
			self.units = None
		
		return offset


class World(object):

	@staticmethod
	def name():
		return 'World'


	def __init__(self, max_cycles=None, bases=None, total_healths=None):
		self.initialize(max_cycles, bases, total_healths)
	

	def initialize(self, max_cycles=None, bases=None, total_healths=None):
		self.max_cycles = max_cycles
		self.bases = bases
		self.total_healths = total_healths
	

	def serialize(self):
		s = b''
		
		# serialize self.max_cycles
		s += b'\x00' if self.max_cycles is None else b'\x01'
		if self.max_cycles is not None:
			s += struct.pack('i', self.max_cycles)
		
		# serialize self.bases
		s += b'\x00' if self.bases is None else b'\x01'
		if self.bases is not None:
			tmp211 = b''
			tmp211 += struct.pack('I', len(self.bases))
			while len(tmp211) and tmp211[-1] == b'\x00'[0]:
				tmp211 = tmp211[:-1]
			s += struct.pack('B', len(tmp211))
			s += tmp211
			
			for tmp212 in self.bases:
				s += b'\x00' if tmp212 is None else b'\x01'
				if tmp212 is not None:
					tmp213 = b''
					tmp213 += struct.pack('I', len(tmp212))
					while len(tmp213) and tmp213[-1] == b'\x00'[0]:
						tmp213 = tmp213[:-1]
					s += struct.pack('B', len(tmp213))
					s += tmp213
					
					s += tmp212.encode('ISO-8859-1') if PY3 else tmp212
				s += b'\x00' if self.bases[tmp212] is None else b'\x01'
				if self.bases[tmp212] is not None:
					s += self.bases[tmp212].serialize()
		
		# serialize self.total_healths
		s += b'\x00' if self.total_healths is None else b'\x01'
		if self.total_healths is not None:
			tmp214 = b''
			tmp214 += struct.pack('I', len(self.total_healths))
			while len(tmp214) and tmp214[-1] == b'\x00'[0]:
				tmp214 = tmp214[:-1]
			s += struct.pack('B', len(tmp214))
			s += tmp214
			
			for tmp215 in self.total_healths:
				s += b'\x00' if tmp215 is None else b'\x01'
				if tmp215 is not None:
					tmp216 = b''
					tmp216 += struct.pack('I', len(tmp215))
					while len(tmp216) and tmp216[-1] == b'\x00'[0]:
						tmp216 = tmp216[:-1]
					s += struct.pack('B', len(tmp216))
					s += tmp216
					
					s += tmp215.encode('ISO-8859-1') if PY3 else tmp215
				s += b'\x00' if self.total_healths[tmp215] is None else b'\x01'
				if self.total_healths[tmp215] is not None:
					s += struct.pack('i', self.total_healths[tmp215])
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize self.max_cycles
		tmp217 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp217:
			self.max_cycles = struct.unpack('i', s[offset:offset + 4])[0]
			offset += 4
		else:
			self.max_cycles = None
		
		# deserialize self.bases
		tmp218 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp218:
			tmp219 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp220 = s[offset:offset + tmp219]
			offset += tmp219
			tmp220 += b'\x00' * (4 - tmp219)
			tmp221 = struct.unpack('I', tmp220)[0]
			
			self.bases = {}
			for tmp222 in range(tmp221):
				tmp225 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp225:
					tmp226 = struct.unpack('B', s[offset:offset + 1])[0]
					offset += 1
					tmp227 = s[offset:offset + tmp226]
					offset += tmp226
					tmp227 += b'\x00' * (4 - tmp226)
					tmp228 = struct.unpack('I', tmp227)[0]
					
					tmp223 = s[offset:offset + tmp228].decode('ISO-8859-1') if PY3 else s[offset:offset + tmp228]
					offset += tmp228
				else:
					tmp223 = None
				tmp229 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp229:
					tmp224 = Base()
					offset = tmp224.deserialize(s, offset)
				else:
					tmp224 = None
				self.bases[tmp223] = tmp224
		else:
			self.bases = None
		
		# deserialize self.total_healths
		tmp230 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp230:
			tmp231 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp232 = s[offset:offset + tmp231]
			offset += tmp231
			tmp232 += b'\x00' * (4 - tmp231)
			tmp233 = struct.unpack('I', tmp232)[0]
			
			self.total_healths = {}
			for tmp234 in range(tmp233):
				tmp237 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp237:
					tmp238 = struct.unpack('B', s[offset:offset + 1])[0]
					offset += 1
					tmp239 = s[offset:offset + tmp238]
					offset += tmp238
					tmp239 += b'\x00' * (4 - tmp238)
					tmp240 = struct.unpack('I', tmp239)[0]
					
					tmp235 = s[offset:offset + tmp240].decode('ISO-8859-1') if PY3 else s[offset:offset + tmp240]
					offset += tmp240
				else:
					tmp235 = None
				tmp241 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp241:
					tmp236 = struct.unpack('i', s[offset:offset + 4])[0]
					offset += 4
				else:
					tmp236 = None
				self.total_healths[tmp235] = tmp236
		else:
			self.total_healths = None
		
		return offset
