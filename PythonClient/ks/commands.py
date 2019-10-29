# -*- coding: utf-8 -*-

# python imports
import sys
import struct
from enum import Enum

PY3 = sys.version_info > (3,)


class CommandMaterialType(Enum):
	Powder = 0
	Steel = 1
	Aluminum = 2
	Shell = 3
	Nickel = 4
	Manganese = 5
	Chromium = 6


class CommandAmmoType(Enum):
	RifleBullet = 0
	TankShell = 1
	Bomb = 2
	ArtilleryShell = 3
	HMGBullet = 4


class CommandAgentType(Enum):
	Warehouse = 0
	Factory = 1


class BaseCommand(object):

	@staticmethod
	def name():
		return 'BaseCommand'


	def __init__(self, agent_type=None):
		self.initialize(agent_type)
	

	def initialize(self, agent_type=None):
		self.agent_type = agent_type
	

	def serialize(self):
		s = b''
		
		# serialize self.agent_type
		s += b'\x00' if self.agent_type is None else b'\x01'
		if self.agent_type is not None:
			s += struct.pack('b', self.agent_type.value)
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize self.agent_type
		tmp0 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp0:
			tmp1 = struct.unpack('b', s[offset:offset + 1])[0]
			offset += 1
			self.agent_type = CommandAgentType(tmp1)
		else:
			self.agent_type = None
		
		return offset


class Move(BaseCommand):

	@staticmethod
	def name():
		return 'Move'


	def __init__(self, agent_type=None, forward=None):
		self.initialize(agent_type, forward)
	

	def initialize(self, agent_type=None, forward=None):
		BaseCommand.initialize(self, agent_type)
		
		self.forward = forward
	

	def serialize(self):
		s = b''
		
		# serialize parents
		s += BaseCommand.serialize(self)
		
		# serialize self.forward
		s += b'\x00' if self.forward is None else b'\x01'
		if self.forward is not None:
			s += struct.pack('?', self.forward)
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize parents
		offset = BaseCommand.deserialize(self, s, offset)
		
		# deserialize self.forward
		tmp2 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp2:
			self.forward = struct.unpack('?', s[offset:offset + 1])[0]
			offset += 1
		else:
			self.forward = None
		
		return offset


class PickMaterial(BaseCommand):

	@staticmethod
	def name():
		return 'PickMaterial'


	def __init__(self, agent_type=None, materials=None):
		self.initialize(agent_type, materials)
	

	def initialize(self, agent_type=None, materials=None):
		BaseCommand.initialize(self, agent_type)
		
		self.materials = materials
	

	def serialize(self):
		s = b''
		
		# serialize parents
		s += BaseCommand.serialize(self)
		
		# serialize self.materials
		s += b'\x00' if self.materials is None else b'\x01'
		if self.materials is not None:
			tmp3 = b''
			tmp3 += struct.pack('I', len(self.materials))
			while len(tmp3) and tmp3[-1] == b'\x00'[0]:
				tmp3 = tmp3[:-1]
			s += struct.pack('B', len(tmp3))
			s += tmp3
			
			for tmp4 in self.materials:
				s += b'\x00' if tmp4 is None else b'\x01'
				if tmp4 is not None:
					s += struct.pack('b', tmp4.value)
				s += b'\x00' if self.materials[tmp4] is None else b'\x01'
				if self.materials[tmp4] is not None:
					s += struct.pack('i', self.materials[tmp4])
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize parents
		offset = BaseCommand.deserialize(self, s, offset)
		
		# deserialize self.materials
		tmp5 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp5:
			tmp6 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp7 = s[offset:offset + tmp6]
			offset += tmp6
			tmp7 += b'\x00' * (4 - tmp6)
			tmp8 = struct.unpack('I', tmp7)[0]
			
			self.materials = {}
			for tmp9 in range(tmp8):
				tmp12 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp12:
					tmp13 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp10 = CommandMaterialType(tmp13)
				else:
					tmp10 = None
				tmp14 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp14:
					tmp11 = struct.unpack('i', s[offset:offset + 4])[0]
					offset += 4
				else:
					tmp11 = None
				self.materials[tmp10] = tmp11
		else:
			self.materials = None
		
		return offset


class PutMaterial(BaseCommand):

	@staticmethod
	def name():
		return 'PutMaterial'


	def __init__(self, agent_type=None, materials=None):
		self.initialize(agent_type, materials)
	

	def initialize(self, agent_type=None, materials=None):
		BaseCommand.initialize(self, agent_type)
		
		self.materials = materials
	

	def serialize(self):
		s = b''
		
		# serialize parents
		s += BaseCommand.serialize(self)
		
		# serialize self.materials
		s += b'\x00' if self.materials is None else b'\x01'
		if self.materials is not None:
			tmp15 = b''
			tmp15 += struct.pack('I', len(self.materials))
			while len(tmp15) and tmp15[-1] == b'\x00'[0]:
				tmp15 = tmp15[:-1]
			s += struct.pack('B', len(tmp15))
			s += tmp15
			
			for tmp16 in self.materials:
				s += b'\x00' if tmp16 is None else b'\x01'
				if tmp16 is not None:
					s += struct.pack('b', tmp16.value)
				s += b'\x00' if self.materials[tmp16] is None else b'\x01'
				if self.materials[tmp16] is not None:
					s += struct.pack('i', self.materials[tmp16])
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize parents
		offset = BaseCommand.deserialize(self, s, offset)
		
		# deserialize self.materials
		tmp17 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp17:
			tmp18 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp19 = s[offset:offset + tmp18]
			offset += tmp18
			tmp19 += b'\x00' * (4 - tmp18)
			tmp20 = struct.unpack('I', tmp19)[0]
			
			self.materials = {}
			for tmp21 in range(tmp20):
				tmp24 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp24:
					tmp25 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp22 = CommandMaterialType(tmp25)
				else:
					tmp22 = None
				tmp26 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp26:
					tmp23 = struct.unpack('i', s[offset:offset + 4])[0]
					offset += 4
				else:
					tmp23 = None
				self.materials[tmp22] = tmp23
		else:
			self.materials = None
		
		return offset


class PickAmmo(BaseCommand):

	@staticmethod
	def name():
		return 'PickAmmo'


	def __init__(self, agent_type=None, ammos=None):
		self.initialize(agent_type, ammos)
	

	def initialize(self, agent_type=None, ammos=None):
		BaseCommand.initialize(self, agent_type)
		
		self.ammos = ammos
	

	def serialize(self):
		s = b''
		
		# serialize parents
		s += BaseCommand.serialize(self)
		
		# serialize self.ammos
		s += b'\x00' if self.ammos is None else b'\x01'
		if self.ammos is not None:
			tmp27 = b''
			tmp27 += struct.pack('I', len(self.ammos))
			while len(tmp27) and tmp27[-1] == b'\x00'[0]:
				tmp27 = tmp27[:-1]
			s += struct.pack('B', len(tmp27))
			s += tmp27
			
			for tmp28 in self.ammos:
				s += b'\x00' if tmp28 is None else b'\x01'
				if tmp28 is not None:
					s += struct.pack('b', tmp28.value)
				s += b'\x00' if self.ammos[tmp28] is None else b'\x01'
				if self.ammos[tmp28] is not None:
					s += struct.pack('i', self.ammos[tmp28])
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize parents
		offset = BaseCommand.deserialize(self, s, offset)
		
		# deserialize self.ammos
		tmp29 = struct.unpack('B', s[offset:offset + 1])[0]
		offset += 1
		if tmp29:
			tmp30 = struct.unpack('B', s[offset:offset + 1])[0]
			offset += 1
			tmp31 = s[offset:offset + tmp30]
			offset += tmp30
			tmp31 += b'\x00' * (4 - tmp30)
			tmp32 = struct.unpack('I', tmp31)[0]
			
			self.ammos = {}
			for tmp33 in range(tmp32):
				tmp36 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp36:
					tmp37 = struct.unpack('b', s[offset:offset + 1])[0]
					offset += 1
					tmp34 = CommandAmmoType(tmp37)
				else:
					tmp34 = None
				tmp38 = struct.unpack('B', s[offset:offset + 1])[0]
				offset += 1
				if tmp38:
					tmp35 = struct.unpack('i', s[offset:offset + 4])[0]
					offset += 4
				else:
					tmp35 = None
				self.ammos[tmp34] = tmp35
		else:
			self.ammos = None
		
		return offset


class PutAmmo(BaseCommand):

	@staticmethod
	def name():
		return 'PutAmmo'


	def __init__(self, agent_type=None):
		self.initialize(agent_type)
	

	def initialize(self, agent_type=None):
		BaseCommand.initialize(self, agent_type)
	

	def serialize(self):
		s = b''
		
		# serialize parents
		s += BaseCommand.serialize(self)
		
		return s
	

	def deserialize(self, s, offset=0):
		# deserialize parents
		offset = BaseCommand.deserialize(self, s, offset)
		
		return offset
