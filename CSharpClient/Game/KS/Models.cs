using System;
using System.Linq;
using System.Collections.Generic;

namespace KS.Models
{
	public enum ECell
	{
		Empty = 0,
		FrontlineDelivery = 1,
		Material = 2,
		BacklineDelivery = 3,
		Machine = 4,
	}
	
	public enum MachineStatus
	{
		Idle = 0,
		Working = 1,
		AmmoReady = 2,
	}
	
	public enum MaterialType
	{
		Powder = 0,
		Steel = 1,
		Aluminum = 2,
		Shell = 3,
		Nickel = 4,
		Manganese = 5,
		Chromium = 6,
	}
	
	public enum AmmoType
	{
		RifleBullet = 0,
		TankShell = 1,
		Bomb = 2,
		ArtilleryShell = 3,
		HMGBullet = 4,
	}
	
	public enum UnitType
	{
		Soldier = 0,
		Tank = 1,
		Aircraft = 2,
		Artillery = 3,
		HeavyMachineGunner = 4,
	}
	
	public enum AgentType
	{
		Warehouse = 0,
		Factory = 1,
	}
	
	public partial class Position : KSObject
	{
		public int? Index { get; set; }
		

		public Position()
		{
		}
		
		public new const string NameStatic = "Position";
		
		public override string Name() => "Position";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize Index
			s.Add((byte)((Index == null) ? 0 : 1));
			if (Index != null)
			{
				s.AddRange(BitConverter.GetBytes((int)Index));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Index
			byte tmp0;
			tmp0 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp0 == 1)
			{
				Index = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				Index = null;
			
			return offset;
		}
	}
	
	public partial class Material : KSObject
	{
		public MaterialType? Type { get; set; }
		public Position Position { get; set; }
		public int? Count { get; set; }
		public int? CCapacity { get; set; }
		

		public Material()
		{
		}
		
		public new const string NameStatic = "Material";
		
		public override string Name() => "Material";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize Type
			s.Add((byte)((Type == null) ? 0 : 1));
			if (Type != null)
			{
				s.Add((byte)((sbyte)Type));
			}
			
			// serialize Position
			s.Add((byte)((Position == null) ? 0 : 1));
			if (Position != null)
			{
				s.AddRange(Position.Serialize());
			}
			
			// serialize Count
			s.Add((byte)((Count == null) ? 0 : 1));
			if (Count != null)
			{
				s.AddRange(BitConverter.GetBytes((int)Count));
			}
			
			// serialize CCapacity
			s.Add((byte)((CCapacity == null) ? 0 : 1));
			if (CCapacity != null)
			{
				s.AddRange(BitConverter.GetBytes((int)CCapacity));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Type
			byte tmp1;
			tmp1 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp1 == 1)
			{
				sbyte tmp2;
				tmp2 = (sbyte)s[(int)offset];
				offset += sizeof(sbyte);
				Type = (MaterialType)tmp2;
			}
			else
				Type = null;
			
			// deserialize Position
			byte tmp3;
			tmp3 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp3 == 1)
			{
				Position = new Position();
				offset = Position.Deserialize(s, offset);
			}
			else
				Position = null;
			
			// deserialize Count
			byte tmp4;
			tmp4 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp4 == 1)
			{
				Count = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				Count = null;
			
			// deserialize CCapacity
			byte tmp5;
			tmp5 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp5 == 1)
			{
				CCapacity = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				CCapacity = null;
			
			return offset;
		}
	}
	
	public partial class Machine : KSObject
	{
		public MachineStatus? Status { get; set; }
		public Position Position { get; set; }
		public AmmoType? CurrentAmmo { get; set; }
		public int? ConstructionRemTime { get; set; }
		

		public Machine()
		{
		}
		
		public new const string NameStatic = "Machine";
		
		public override string Name() => "Machine";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize Status
			s.Add((byte)((Status == null) ? 0 : 1));
			if (Status != null)
			{
				s.Add((byte)((sbyte)Status));
			}
			
			// serialize Position
			s.Add((byte)((Position == null) ? 0 : 1));
			if (Position != null)
			{
				s.AddRange(Position.Serialize());
			}
			
			// serialize CurrentAmmo
			s.Add((byte)((CurrentAmmo == null) ? 0 : 1));
			if (CurrentAmmo != null)
			{
				s.Add((byte)((sbyte)CurrentAmmo));
			}
			
			// serialize ConstructionRemTime
			s.Add((byte)((ConstructionRemTime == null) ? 0 : 1));
			if (ConstructionRemTime != null)
			{
				s.AddRange(BitConverter.GetBytes((int)ConstructionRemTime));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Status
			byte tmp6;
			tmp6 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp6 == 1)
			{
				sbyte tmp7;
				tmp7 = (sbyte)s[(int)offset];
				offset += sizeof(sbyte);
				Status = (MachineStatus)tmp7;
			}
			else
				Status = null;
			
			// deserialize Position
			byte tmp8;
			tmp8 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp8 == 1)
			{
				Position = new Position();
				offset = Position.Deserialize(s, offset);
			}
			else
				Position = null;
			
			// deserialize CurrentAmmo
			byte tmp9;
			tmp9 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp9 == 1)
			{
				sbyte tmp10;
				tmp10 = (sbyte)s[(int)offset];
				offset += sizeof(sbyte);
				CurrentAmmo = (AmmoType)tmp10;
			}
			else
				CurrentAmmo = null;
			
			// deserialize ConstructionRemTime
			byte tmp11;
			tmp11 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp11 == 1)
			{
				ConstructionRemTime = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				ConstructionRemTime = null;
			
			return offset;
		}
	}
	
	public partial class FrontlineDelivery : KSObject
	{
		public Dictionary<AmmoType?, int?> Ammos { get; set; }
		public int? DeliveryRemTime { get; set; }
		public int? CDeliveryDuration { get; set; }
		

		public FrontlineDelivery()
		{
		}
		
		public new const string NameStatic = "FrontlineDelivery";
		
		public override string Name() => "FrontlineDelivery";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize Ammos
			s.Add((byte)((Ammos == null) ? 0 : 1));
			if (Ammos != null)
			{
				List<byte> tmp12 = new List<byte>();
				tmp12.AddRange(BitConverter.GetBytes((uint)Ammos.Count()));
				while (tmp12.Count > 0 && tmp12.Last() == 0)
					tmp12.RemoveAt(tmp12.Count - 1);
				s.Add((byte)tmp12.Count);
				s.AddRange(tmp12);
				
				foreach (var tmp13 in Ammos)
				{
					s.Add((byte)((tmp13.Key == null) ? 0 : 1));
					if (tmp13.Key != null)
					{
						s.Add((byte)((sbyte)tmp13.Key));
					}
					
					s.Add((byte)((tmp13.Value == null) ? 0 : 1));
					if (tmp13.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp13.Value));
					}
				}
			}
			
			// serialize DeliveryRemTime
			s.Add((byte)((DeliveryRemTime == null) ? 0 : 1));
			if (DeliveryRemTime != null)
			{
				s.AddRange(BitConverter.GetBytes((int)DeliveryRemTime));
			}
			
			// serialize CDeliveryDuration
			s.Add((byte)((CDeliveryDuration == null) ? 0 : 1));
			if (CDeliveryDuration != null)
			{
				s.AddRange(BitConverter.GetBytes((int)CDeliveryDuration));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Ammos
			byte tmp14;
			tmp14 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp14 == 1)
			{
				byte tmp15;
				tmp15 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp16 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp16, 0, tmp15);
				offset += tmp15;
				uint tmp17;
				tmp17 = BitConverter.ToUInt32(tmp16, (int)0);
				
				Ammos = new Dictionary<AmmoType?, int?>();
				for (uint tmp18 = 0; tmp18 < tmp17; tmp18++)
				{
					AmmoType? tmp19;
					byte tmp21;
					tmp21 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp21 == 1)
					{
						sbyte tmp22;
						tmp22 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp19 = (AmmoType)tmp22;
					}
					else
						tmp19 = null;
					
					int? tmp20;
					byte tmp23;
					tmp23 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp23 == 1)
					{
						tmp20 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp20 = null;
					
					Ammos[tmp19] = tmp20;
				}
			}
			else
				Ammos = null;
			
			// deserialize DeliveryRemTime
			byte tmp24;
			tmp24 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp24 == 1)
			{
				DeliveryRemTime = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				DeliveryRemTime = null;
			
			// deserialize CDeliveryDuration
			byte tmp25;
			tmp25 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp25 == 1)
			{
				CDeliveryDuration = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				CDeliveryDuration = null;
			
			return offset;
		}
	}
	
	public partial class Warehouse : KSObject
	{
		public Dictionary<Position, Material> Materials { get; set; }
		public int? MaterialsReloadRemTime { get; set; }
		public int? CMaterialsReloadDuration { get; set; }
		

		public Warehouse()
		{
		}
		
		public new const string NameStatic = "Warehouse";
		
		public override string Name() => "Warehouse";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize Materials
			s.Add((byte)((Materials == null) ? 0 : 1));
			if (Materials != null)
			{
				List<byte> tmp26 = new List<byte>();
				tmp26.AddRange(BitConverter.GetBytes((uint)Materials.Count()));
				while (tmp26.Count > 0 && tmp26.Last() == 0)
					tmp26.RemoveAt(tmp26.Count - 1);
				s.Add((byte)tmp26.Count);
				s.AddRange(tmp26);
				
				foreach (var tmp27 in Materials)
				{
					s.Add((byte)((tmp27.Key == null) ? 0 : 1));
					if (tmp27.Key != null)
					{
						s.AddRange(tmp27.Key.Serialize());
					}
					
					s.Add((byte)((tmp27.Value == null) ? 0 : 1));
					if (tmp27.Value != null)
					{
						s.AddRange(tmp27.Value.Serialize());
					}
				}
			}
			
			// serialize MaterialsReloadRemTime
			s.Add((byte)((MaterialsReloadRemTime == null) ? 0 : 1));
			if (MaterialsReloadRemTime != null)
			{
				s.AddRange(BitConverter.GetBytes((int)MaterialsReloadRemTime));
			}
			
			// serialize CMaterialsReloadDuration
			s.Add((byte)((CMaterialsReloadDuration == null) ? 0 : 1));
			if (CMaterialsReloadDuration != null)
			{
				s.AddRange(BitConverter.GetBytes((int)CMaterialsReloadDuration));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Materials
			byte tmp28;
			tmp28 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp28 == 1)
			{
				byte tmp29;
				tmp29 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp30 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp30, 0, tmp29);
				offset += tmp29;
				uint tmp31;
				tmp31 = BitConverter.ToUInt32(tmp30, (int)0);
				
				Materials = new Dictionary<Position, Material>();
				for (uint tmp32 = 0; tmp32 < tmp31; tmp32++)
				{
					Position tmp33;
					byte tmp35;
					tmp35 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp35 == 1)
					{
						tmp33 = new Position();
						offset = tmp33.Deserialize(s, offset);
					}
					else
						tmp33 = null;
					
					Material tmp34;
					byte tmp36;
					tmp36 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp36 == 1)
					{
						tmp34 = new Material();
						offset = tmp34.Deserialize(s, offset);
					}
					else
						tmp34 = null;
					
					Materials[tmp33] = tmp34;
				}
			}
			else
				Materials = null;
			
			// deserialize MaterialsReloadRemTime
			byte tmp37;
			tmp37 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp37 == 1)
			{
				MaterialsReloadRemTime = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				MaterialsReloadRemTime = null;
			
			// deserialize CMaterialsReloadDuration
			byte tmp38;
			tmp38 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp38 == 1)
			{
				CMaterialsReloadDuration = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				CMaterialsReloadDuration = null;
			
			return offset;
		}
	}
	
	public partial class BacklineDelivery : KSObject
	{
		public Dictionary<MaterialType?, int?> Materials { get; set; }
		public Dictionary<AmmoType?, int?> Ammos { get; set; }
		

		public BacklineDelivery()
		{
		}
		
		public new const string NameStatic = "BacklineDelivery";
		
		public override string Name() => "BacklineDelivery";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize Materials
			s.Add((byte)((Materials == null) ? 0 : 1));
			if (Materials != null)
			{
				List<byte> tmp39 = new List<byte>();
				tmp39.AddRange(BitConverter.GetBytes((uint)Materials.Count()));
				while (tmp39.Count > 0 && tmp39.Last() == 0)
					tmp39.RemoveAt(tmp39.Count - 1);
				s.Add((byte)tmp39.Count);
				s.AddRange(tmp39);
				
				foreach (var tmp40 in Materials)
				{
					s.Add((byte)((tmp40.Key == null) ? 0 : 1));
					if (tmp40.Key != null)
					{
						s.Add((byte)((sbyte)tmp40.Key));
					}
					
					s.Add((byte)((tmp40.Value == null) ? 0 : 1));
					if (tmp40.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp40.Value));
					}
				}
			}
			
			// serialize Ammos
			s.Add((byte)((Ammos == null) ? 0 : 1));
			if (Ammos != null)
			{
				List<byte> tmp41 = new List<byte>();
				tmp41.AddRange(BitConverter.GetBytes((uint)Ammos.Count()));
				while (tmp41.Count > 0 && tmp41.Last() == 0)
					tmp41.RemoveAt(tmp41.Count - 1);
				s.Add((byte)tmp41.Count);
				s.AddRange(tmp41);
				
				foreach (var tmp42 in Ammos)
				{
					s.Add((byte)((tmp42.Key == null) ? 0 : 1));
					if (tmp42.Key != null)
					{
						s.Add((byte)((sbyte)tmp42.Key));
					}
					
					s.Add((byte)((tmp42.Value == null) ? 0 : 1));
					if (tmp42.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp42.Value));
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Materials
			byte tmp43;
			tmp43 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp43 == 1)
			{
				byte tmp44;
				tmp44 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp45 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp45, 0, tmp44);
				offset += tmp44;
				uint tmp46;
				tmp46 = BitConverter.ToUInt32(tmp45, (int)0);
				
				Materials = new Dictionary<MaterialType?, int?>();
				for (uint tmp47 = 0; tmp47 < tmp46; tmp47++)
				{
					MaterialType? tmp48;
					byte tmp50;
					tmp50 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp50 == 1)
					{
						sbyte tmp51;
						tmp51 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp48 = (MaterialType)tmp51;
					}
					else
						tmp48 = null;
					
					int? tmp49;
					byte tmp52;
					tmp52 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp52 == 1)
					{
						tmp49 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp49 = null;
					
					Materials[tmp48] = tmp49;
				}
			}
			else
				Materials = null;
			
			// deserialize Ammos
			byte tmp53;
			tmp53 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp53 == 1)
			{
				byte tmp54;
				tmp54 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp55 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp55, 0, tmp54);
				offset += tmp54;
				uint tmp56;
				tmp56 = BitConverter.ToUInt32(tmp55, (int)0);
				
				Ammos = new Dictionary<AmmoType?, int?>();
				for (uint tmp57 = 0; tmp57 < tmp56; tmp57++)
				{
					AmmoType? tmp58;
					byte tmp60;
					tmp60 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp60 == 1)
					{
						sbyte tmp61;
						tmp61 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp58 = (AmmoType)tmp61;
					}
					else
						tmp58 = null;
					
					int? tmp59;
					byte tmp62;
					tmp62 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp62 == 1)
					{
						tmp59 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp59 = null;
					
					Ammos[tmp58] = tmp59;
				}
			}
			else
				Ammos = null;
			
			return offset;
		}
	}
	
	public partial class Factory : KSObject
	{
		public Dictionary<Position, Machine> Machines { get; set; }
		public Dictionary<AmmoType?, Dictionary<MaterialType?, int?>> CMixtureFormulas { get; set; }
		public Dictionary<AmmoType?, int?> CConstructionDurations { get; set; }
		public Dictionary<AmmoType?, int?> CAmmoBoxSizes { get; set; }
		

		public Factory()
		{
		}
		
		public new const string NameStatic = "Factory";
		
		public override string Name() => "Factory";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize Machines
			s.Add((byte)((Machines == null) ? 0 : 1));
			if (Machines != null)
			{
				List<byte> tmp63 = new List<byte>();
				tmp63.AddRange(BitConverter.GetBytes((uint)Machines.Count()));
				while (tmp63.Count > 0 && tmp63.Last() == 0)
					tmp63.RemoveAt(tmp63.Count - 1);
				s.Add((byte)tmp63.Count);
				s.AddRange(tmp63);
				
				foreach (var tmp64 in Machines)
				{
					s.Add((byte)((tmp64.Key == null) ? 0 : 1));
					if (tmp64.Key != null)
					{
						s.AddRange(tmp64.Key.Serialize());
					}
					
					s.Add((byte)((tmp64.Value == null) ? 0 : 1));
					if (tmp64.Value != null)
					{
						s.AddRange(tmp64.Value.Serialize());
					}
				}
			}
			
			// serialize CMixtureFormulas
			s.Add((byte)((CMixtureFormulas == null) ? 0 : 1));
			if (CMixtureFormulas != null)
			{
				List<byte> tmp65 = new List<byte>();
				tmp65.AddRange(BitConverter.GetBytes((uint)CMixtureFormulas.Count()));
				while (tmp65.Count > 0 && tmp65.Last() == 0)
					tmp65.RemoveAt(tmp65.Count - 1);
				s.Add((byte)tmp65.Count);
				s.AddRange(tmp65);
				
				foreach (var tmp66 in CMixtureFormulas)
				{
					s.Add((byte)((tmp66.Key == null) ? 0 : 1));
					if (tmp66.Key != null)
					{
						s.Add((byte)((sbyte)tmp66.Key));
					}
					
					s.Add((byte)((tmp66.Value == null) ? 0 : 1));
					if (tmp66.Value != null)
					{
						List<byte> tmp67 = new List<byte>();
						tmp67.AddRange(BitConverter.GetBytes((uint)tmp66.Value.Count()));
						while (tmp67.Count > 0 && tmp67.Last() == 0)
							tmp67.RemoveAt(tmp67.Count - 1);
						s.Add((byte)tmp67.Count);
						s.AddRange(tmp67);
						
						foreach (var tmp68 in tmp66.Value)
						{
							s.Add((byte)((tmp68.Key == null) ? 0 : 1));
							if (tmp68.Key != null)
							{
								s.Add((byte)((sbyte)tmp68.Key));
							}
							
							s.Add((byte)((tmp68.Value == null) ? 0 : 1));
							if (tmp68.Value != null)
							{
								s.AddRange(BitConverter.GetBytes((int)tmp68.Value));
							}
						}
					}
				}
			}
			
			// serialize CConstructionDurations
			s.Add((byte)((CConstructionDurations == null) ? 0 : 1));
			if (CConstructionDurations != null)
			{
				List<byte> tmp69 = new List<byte>();
				tmp69.AddRange(BitConverter.GetBytes((uint)CConstructionDurations.Count()));
				while (tmp69.Count > 0 && tmp69.Last() == 0)
					tmp69.RemoveAt(tmp69.Count - 1);
				s.Add((byte)tmp69.Count);
				s.AddRange(tmp69);
				
				foreach (var tmp70 in CConstructionDurations)
				{
					s.Add((byte)((tmp70.Key == null) ? 0 : 1));
					if (tmp70.Key != null)
					{
						s.Add((byte)((sbyte)tmp70.Key));
					}
					
					s.Add((byte)((tmp70.Value == null) ? 0 : 1));
					if (tmp70.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp70.Value));
					}
				}
			}
			
			// serialize CAmmoBoxSizes
			s.Add((byte)((CAmmoBoxSizes == null) ? 0 : 1));
			if (CAmmoBoxSizes != null)
			{
				List<byte> tmp71 = new List<byte>();
				tmp71.AddRange(BitConverter.GetBytes((uint)CAmmoBoxSizes.Count()));
				while (tmp71.Count > 0 && tmp71.Last() == 0)
					tmp71.RemoveAt(tmp71.Count - 1);
				s.Add((byte)tmp71.Count);
				s.AddRange(tmp71);
				
				foreach (var tmp72 in CAmmoBoxSizes)
				{
					s.Add((byte)((tmp72.Key == null) ? 0 : 1));
					if (tmp72.Key != null)
					{
						s.Add((byte)((sbyte)tmp72.Key));
					}
					
					s.Add((byte)((tmp72.Value == null) ? 0 : 1));
					if (tmp72.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp72.Value));
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Machines
			byte tmp73;
			tmp73 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp73 == 1)
			{
				byte tmp74;
				tmp74 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp75 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp75, 0, tmp74);
				offset += tmp74;
				uint tmp76;
				tmp76 = BitConverter.ToUInt32(tmp75, (int)0);
				
				Machines = new Dictionary<Position, Machine>();
				for (uint tmp77 = 0; tmp77 < tmp76; tmp77++)
				{
					Position tmp78;
					byte tmp80;
					tmp80 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp80 == 1)
					{
						tmp78 = new Position();
						offset = tmp78.Deserialize(s, offset);
					}
					else
						tmp78 = null;
					
					Machine tmp79;
					byte tmp81;
					tmp81 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp81 == 1)
					{
						tmp79 = new Machine();
						offset = tmp79.Deserialize(s, offset);
					}
					else
						tmp79 = null;
					
					Machines[tmp78] = tmp79;
				}
			}
			else
				Machines = null;
			
			// deserialize CMixtureFormulas
			byte tmp82;
			tmp82 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp82 == 1)
			{
				byte tmp83;
				tmp83 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp84 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp84, 0, tmp83);
				offset += tmp83;
				uint tmp85;
				tmp85 = BitConverter.ToUInt32(tmp84, (int)0);
				
				CMixtureFormulas = new Dictionary<AmmoType?, Dictionary<MaterialType?, int?>>();
				for (uint tmp86 = 0; tmp86 < tmp85; tmp86++)
				{
					AmmoType? tmp87;
					byte tmp89;
					tmp89 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp89 == 1)
					{
						sbyte tmp90;
						tmp90 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp87 = (AmmoType)tmp90;
					}
					else
						tmp87 = null;
					
					Dictionary<MaterialType?, int?> tmp88;
					byte tmp91;
					tmp91 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp91 == 1)
					{
						byte tmp92;
						tmp92 = (byte)s[(int)offset];
						offset += sizeof(byte);
						byte[] tmp93 = new byte[sizeof(uint)];
						Array.Copy(s, offset, tmp93, 0, tmp92);
						offset += tmp92;
						uint tmp94;
						tmp94 = BitConverter.ToUInt32(tmp93, (int)0);
						
						tmp88 = new Dictionary<MaterialType?, int?>();
						for (uint tmp95 = 0; tmp95 < tmp94; tmp95++)
						{
							MaterialType? tmp96;
							byte tmp98;
							tmp98 = (byte)s[(int)offset];
							offset += sizeof(byte);
							if (tmp98 == 1)
							{
								sbyte tmp99;
								tmp99 = (sbyte)s[(int)offset];
								offset += sizeof(sbyte);
								tmp96 = (MaterialType)tmp99;
							}
							else
								tmp96 = null;
							
							int? tmp97;
							byte tmp100;
							tmp100 = (byte)s[(int)offset];
							offset += sizeof(byte);
							if (tmp100 == 1)
							{
								tmp97 = BitConverter.ToInt32(s, (int)offset);
								offset += sizeof(int);
							}
							else
								tmp97 = null;
							
							tmp88[tmp96] = tmp97;
						}
					}
					else
						tmp88 = null;
					
					CMixtureFormulas[tmp87] = tmp88;
				}
			}
			else
				CMixtureFormulas = null;
			
			// deserialize CConstructionDurations
			byte tmp101;
			tmp101 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp101 == 1)
			{
				byte tmp102;
				tmp102 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp103 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp103, 0, tmp102);
				offset += tmp102;
				uint tmp104;
				tmp104 = BitConverter.ToUInt32(tmp103, (int)0);
				
				CConstructionDurations = new Dictionary<AmmoType?, int?>();
				for (uint tmp105 = 0; tmp105 < tmp104; tmp105++)
				{
					AmmoType? tmp106;
					byte tmp108;
					tmp108 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp108 == 1)
					{
						sbyte tmp109;
						tmp109 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp106 = (AmmoType)tmp109;
					}
					else
						tmp106 = null;
					
					int? tmp107;
					byte tmp110;
					tmp110 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp110 == 1)
					{
						tmp107 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp107 = null;
					
					CConstructionDurations[tmp106] = tmp107;
				}
			}
			else
				CConstructionDurations = null;
			
			// deserialize CAmmoBoxSizes
			byte tmp111;
			tmp111 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp111 == 1)
			{
				byte tmp112;
				tmp112 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp113 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp113, 0, tmp112);
				offset += tmp112;
				uint tmp114;
				tmp114 = BitConverter.ToUInt32(tmp113, (int)0);
				
				CAmmoBoxSizes = new Dictionary<AmmoType?, int?>();
				for (uint tmp115 = 0; tmp115 < tmp114; tmp115++)
				{
					AmmoType? tmp116;
					byte tmp118;
					tmp118 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp118 == 1)
					{
						sbyte tmp119;
						tmp119 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp116 = (AmmoType)tmp119;
					}
					else
						tmp116 = null;
					
					int? tmp117;
					byte tmp120;
					tmp120 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp120 == 1)
					{
						tmp117 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp117 = null;
					
					CAmmoBoxSizes[tmp116] = tmp117;
				}
			}
			else
				CAmmoBoxSizes = null;
			
			return offset;
		}
	}
	
	public partial class Agent : KSObject
	{
		public AgentType? Type { get; set; }
		public Position Position { get; set; }
		public Dictionary<MaterialType?, int?> MaterialsBag { get; set; }
		public int? CMaterialsBagCapacity { get; set; }
		public Dictionary<AmmoType?, int?> AmmosBag { get; set; }
		public int? CAmmosBagCapacity { get; set; }
		

		public Agent()
		{
		}
		
		public new const string NameStatic = "Agent";
		
		public override string Name() => "Agent";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize Type
			s.Add((byte)((Type == null) ? 0 : 1));
			if (Type != null)
			{
				s.Add((byte)((sbyte)Type));
			}
			
			// serialize Position
			s.Add((byte)((Position == null) ? 0 : 1));
			if (Position != null)
			{
				s.AddRange(Position.Serialize());
			}
			
			// serialize MaterialsBag
			s.Add((byte)((MaterialsBag == null) ? 0 : 1));
			if (MaterialsBag != null)
			{
				List<byte> tmp121 = new List<byte>();
				tmp121.AddRange(BitConverter.GetBytes((uint)MaterialsBag.Count()));
				while (tmp121.Count > 0 && tmp121.Last() == 0)
					tmp121.RemoveAt(tmp121.Count - 1);
				s.Add((byte)tmp121.Count);
				s.AddRange(tmp121);
				
				foreach (var tmp122 in MaterialsBag)
				{
					s.Add((byte)((tmp122.Key == null) ? 0 : 1));
					if (tmp122.Key != null)
					{
						s.Add((byte)((sbyte)tmp122.Key));
					}
					
					s.Add((byte)((tmp122.Value == null) ? 0 : 1));
					if (tmp122.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp122.Value));
					}
				}
			}
			
			// serialize CMaterialsBagCapacity
			s.Add((byte)((CMaterialsBagCapacity == null) ? 0 : 1));
			if (CMaterialsBagCapacity != null)
			{
				s.AddRange(BitConverter.GetBytes((int)CMaterialsBagCapacity));
			}
			
			// serialize AmmosBag
			s.Add((byte)((AmmosBag == null) ? 0 : 1));
			if (AmmosBag != null)
			{
				List<byte> tmp123 = new List<byte>();
				tmp123.AddRange(BitConverter.GetBytes((uint)AmmosBag.Count()));
				while (tmp123.Count > 0 && tmp123.Last() == 0)
					tmp123.RemoveAt(tmp123.Count - 1);
				s.Add((byte)tmp123.Count);
				s.AddRange(tmp123);
				
				foreach (var tmp124 in AmmosBag)
				{
					s.Add((byte)((tmp124.Key == null) ? 0 : 1));
					if (tmp124.Key != null)
					{
						s.Add((byte)((sbyte)tmp124.Key));
					}
					
					s.Add((byte)((tmp124.Value == null) ? 0 : 1));
					if (tmp124.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp124.Value));
					}
				}
			}
			
			// serialize CAmmosBagCapacity
			s.Add((byte)((CAmmosBagCapacity == null) ? 0 : 1));
			if (CAmmosBagCapacity != null)
			{
				s.AddRange(BitConverter.GetBytes((int)CAmmosBagCapacity));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Type
			byte tmp125;
			tmp125 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp125 == 1)
			{
				sbyte tmp126;
				tmp126 = (sbyte)s[(int)offset];
				offset += sizeof(sbyte);
				Type = (AgentType)tmp126;
			}
			else
				Type = null;
			
			// deserialize Position
			byte tmp127;
			tmp127 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp127 == 1)
			{
				Position = new Position();
				offset = Position.Deserialize(s, offset);
			}
			else
				Position = null;
			
			// deserialize MaterialsBag
			byte tmp128;
			tmp128 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp128 == 1)
			{
				byte tmp129;
				tmp129 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp130 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp130, 0, tmp129);
				offset += tmp129;
				uint tmp131;
				tmp131 = BitConverter.ToUInt32(tmp130, (int)0);
				
				MaterialsBag = new Dictionary<MaterialType?, int?>();
				for (uint tmp132 = 0; tmp132 < tmp131; tmp132++)
				{
					MaterialType? tmp133;
					byte tmp135;
					tmp135 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp135 == 1)
					{
						sbyte tmp136;
						tmp136 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp133 = (MaterialType)tmp136;
					}
					else
						tmp133 = null;
					
					int? tmp134;
					byte tmp137;
					tmp137 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp137 == 1)
					{
						tmp134 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp134 = null;
					
					MaterialsBag[tmp133] = tmp134;
				}
			}
			else
				MaterialsBag = null;
			
			// deserialize CMaterialsBagCapacity
			byte tmp138;
			tmp138 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp138 == 1)
			{
				CMaterialsBagCapacity = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				CMaterialsBagCapacity = null;
			
			// deserialize AmmosBag
			byte tmp139;
			tmp139 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp139 == 1)
			{
				byte tmp140;
				tmp140 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp141 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp141, 0, tmp140);
				offset += tmp140;
				uint tmp142;
				tmp142 = BitConverter.ToUInt32(tmp141, (int)0);
				
				AmmosBag = new Dictionary<AmmoType?, int?>();
				for (uint tmp143 = 0; tmp143 < tmp142; tmp143++)
				{
					AmmoType? tmp144;
					byte tmp146;
					tmp146 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp146 == 1)
					{
						sbyte tmp147;
						tmp147 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp144 = (AmmoType)tmp147;
					}
					else
						tmp144 = null;
					
					int? tmp145;
					byte tmp148;
					tmp148 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp148 == 1)
					{
						tmp145 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp145 = null;
					
					AmmosBag[tmp144] = tmp145;
				}
			}
			else
				AmmosBag = null;
			
			// deserialize CAmmosBagCapacity
			byte tmp149;
			tmp149 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp149 == 1)
			{
				CAmmosBagCapacity = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				CAmmosBagCapacity = null;
			
			return offset;
		}
	}
	
	public partial class Unit : KSObject
	{
		public UnitType? Type { get; set; }
		public int? Health { get; set; }
		public int? CIndividualHealth { get; set; }
		public int? CIndividualDamage { get; set; }
		public Dictionary<UnitType?, float?> CDamageDistribution { get; set; }
		public int? AmmoCount { get; set; }
		public int? ReloadRemTime { get; set; }
		public int? CReloadDuration { get; set; }
		

		public Unit()
		{
		}
		
		public new const string NameStatic = "Unit";
		
		public override string Name() => "Unit";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize Type
			s.Add((byte)((Type == null) ? 0 : 1));
			if (Type != null)
			{
				s.Add((byte)((sbyte)Type));
			}
			
			// serialize Health
			s.Add((byte)((Health == null) ? 0 : 1));
			if (Health != null)
			{
				s.AddRange(BitConverter.GetBytes((int)Health));
			}
			
			// serialize CIndividualHealth
			s.Add((byte)((CIndividualHealth == null) ? 0 : 1));
			if (CIndividualHealth != null)
			{
				s.AddRange(BitConverter.GetBytes((int)CIndividualHealth));
			}
			
			// serialize CIndividualDamage
			s.Add((byte)((CIndividualDamage == null) ? 0 : 1));
			if (CIndividualDamage != null)
			{
				s.AddRange(BitConverter.GetBytes((int)CIndividualDamage));
			}
			
			// serialize CDamageDistribution
			s.Add((byte)((CDamageDistribution == null) ? 0 : 1));
			if (CDamageDistribution != null)
			{
				List<byte> tmp150 = new List<byte>();
				tmp150.AddRange(BitConverter.GetBytes((uint)CDamageDistribution.Count()));
				while (tmp150.Count > 0 && tmp150.Last() == 0)
					tmp150.RemoveAt(tmp150.Count - 1);
				s.Add((byte)tmp150.Count);
				s.AddRange(tmp150);
				
				foreach (var tmp151 in CDamageDistribution)
				{
					s.Add((byte)((tmp151.Key == null) ? 0 : 1));
					if (tmp151.Key != null)
					{
						s.Add((byte)((sbyte)tmp151.Key));
					}
					
					s.Add((byte)((tmp151.Value == null) ? 0 : 1));
					if (tmp151.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((float)tmp151.Value));
					}
				}
			}
			
			// serialize AmmoCount
			s.Add((byte)((AmmoCount == null) ? 0 : 1));
			if (AmmoCount != null)
			{
				s.AddRange(BitConverter.GetBytes((int)AmmoCount));
			}
			
			// serialize ReloadRemTime
			s.Add((byte)((ReloadRemTime == null) ? 0 : 1));
			if (ReloadRemTime != null)
			{
				s.AddRange(BitConverter.GetBytes((int)ReloadRemTime));
			}
			
			// serialize CReloadDuration
			s.Add((byte)((CReloadDuration == null) ? 0 : 1));
			if (CReloadDuration != null)
			{
				s.AddRange(BitConverter.GetBytes((int)CReloadDuration));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Type
			byte tmp152;
			tmp152 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp152 == 1)
			{
				sbyte tmp153;
				tmp153 = (sbyte)s[(int)offset];
				offset += sizeof(sbyte);
				Type = (UnitType)tmp153;
			}
			else
				Type = null;
			
			// deserialize Health
			byte tmp154;
			tmp154 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp154 == 1)
			{
				Health = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				Health = null;
			
			// deserialize CIndividualHealth
			byte tmp155;
			tmp155 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp155 == 1)
			{
				CIndividualHealth = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				CIndividualHealth = null;
			
			// deserialize CIndividualDamage
			byte tmp156;
			tmp156 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp156 == 1)
			{
				CIndividualDamage = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				CIndividualDamage = null;
			
			// deserialize CDamageDistribution
			byte tmp157;
			tmp157 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp157 == 1)
			{
				byte tmp158;
				tmp158 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp159 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp159, 0, tmp158);
				offset += tmp158;
				uint tmp160;
				tmp160 = BitConverter.ToUInt32(tmp159, (int)0);
				
				CDamageDistribution = new Dictionary<UnitType?, float?>();
				for (uint tmp161 = 0; tmp161 < tmp160; tmp161++)
				{
					UnitType? tmp162;
					byte tmp164;
					tmp164 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp164 == 1)
					{
						sbyte tmp165;
						tmp165 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp162 = (UnitType)tmp165;
					}
					else
						tmp162 = null;
					
					float? tmp163;
					byte tmp166;
					tmp166 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp166 == 1)
					{
						tmp163 = BitConverter.ToSingle(s, (int)offset);
						offset += sizeof(float);
					}
					else
						tmp163 = null;
					
					CDamageDistribution[tmp162] = tmp163;
				}
			}
			else
				CDamageDistribution = null;
			
			// deserialize AmmoCount
			byte tmp167;
			tmp167 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp167 == 1)
			{
				AmmoCount = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				AmmoCount = null;
			
			// deserialize ReloadRemTime
			byte tmp168;
			tmp168 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp168 == 1)
			{
				ReloadRemTime = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				ReloadRemTime = null;
			
			// deserialize CReloadDuration
			byte tmp169;
			tmp169 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp169 == 1)
			{
				CReloadDuration = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				CReloadDuration = null;
			
			return offset;
		}
	}
	
	public partial class Base : KSObject
	{
		public List<ECell?> CArea { get; set; }
		public Dictionary<AgentType?, Agent> Agents { get; set; }
		public List<FrontlineDelivery> FrontlineDeliveries { get; set; }
		public Warehouse Warehouse { get; set; }
		public BacklineDelivery BacklineDelivery { get; set; }
		public Factory Factory { get; set; }
		public Dictionary<UnitType?, Unit> Units { get; set; }
		

		public Base()
		{
		}
		
		public new const string NameStatic = "Base";
		
		public override string Name() => "Base";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize CArea
			s.Add((byte)((CArea == null) ? 0 : 1));
			if (CArea != null)
			{
				List<byte> tmp170 = new List<byte>();
				tmp170.AddRange(BitConverter.GetBytes((uint)CArea.Count()));
				while (tmp170.Count > 0 && tmp170.Last() == 0)
					tmp170.RemoveAt(tmp170.Count - 1);
				s.Add((byte)tmp170.Count);
				s.AddRange(tmp170);
				
				foreach (var tmp171 in CArea)
				{
					s.Add((byte)((tmp171 == null) ? 0 : 1));
					if (tmp171 != null)
					{
						s.Add((byte)((sbyte)tmp171));
					}
				}
			}
			
			// serialize Agents
			s.Add((byte)((Agents == null) ? 0 : 1));
			if (Agents != null)
			{
				List<byte> tmp172 = new List<byte>();
				tmp172.AddRange(BitConverter.GetBytes((uint)Agents.Count()));
				while (tmp172.Count > 0 && tmp172.Last() == 0)
					tmp172.RemoveAt(tmp172.Count - 1);
				s.Add((byte)tmp172.Count);
				s.AddRange(tmp172);
				
				foreach (var tmp173 in Agents)
				{
					s.Add((byte)((tmp173.Key == null) ? 0 : 1));
					if (tmp173.Key != null)
					{
						s.Add((byte)((sbyte)tmp173.Key));
					}
					
					s.Add((byte)((tmp173.Value == null) ? 0 : 1));
					if (tmp173.Value != null)
					{
						s.AddRange(tmp173.Value.Serialize());
					}
				}
			}
			
			// serialize FrontlineDeliveries
			s.Add((byte)((FrontlineDeliveries == null) ? 0 : 1));
			if (FrontlineDeliveries != null)
			{
				List<byte> tmp174 = new List<byte>();
				tmp174.AddRange(BitConverter.GetBytes((uint)FrontlineDeliveries.Count()));
				while (tmp174.Count > 0 && tmp174.Last() == 0)
					tmp174.RemoveAt(tmp174.Count - 1);
				s.Add((byte)tmp174.Count);
				s.AddRange(tmp174);
				
				foreach (var tmp175 in FrontlineDeliveries)
				{
					s.Add((byte)((tmp175 == null) ? 0 : 1));
					if (tmp175 != null)
					{
						s.AddRange(tmp175.Serialize());
					}
				}
			}
			
			// serialize Warehouse
			s.Add((byte)((Warehouse == null) ? 0 : 1));
			if (Warehouse != null)
			{
				s.AddRange(Warehouse.Serialize());
			}
			
			// serialize BacklineDelivery
			s.Add((byte)((BacklineDelivery == null) ? 0 : 1));
			if (BacklineDelivery != null)
			{
				s.AddRange(BacklineDelivery.Serialize());
			}
			
			// serialize Factory
			s.Add((byte)((Factory == null) ? 0 : 1));
			if (Factory != null)
			{
				s.AddRange(Factory.Serialize());
			}
			
			// serialize Units
			s.Add((byte)((Units == null) ? 0 : 1));
			if (Units != null)
			{
				List<byte> tmp176 = new List<byte>();
				tmp176.AddRange(BitConverter.GetBytes((uint)Units.Count()));
				while (tmp176.Count > 0 && tmp176.Last() == 0)
					tmp176.RemoveAt(tmp176.Count - 1);
				s.Add((byte)tmp176.Count);
				s.AddRange(tmp176);
				
				foreach (var tmp177 in Units)
				{
					s.Add((byte)((tmp177.Key == null) ? 0 : 1));
					if (tmp177.Key != null)
					{
						s.Add((byte)((sbyte)tmp177.Key));
					}
					
					s.Add((byte)((tmp177.Value == null) ? 0 : 1));
					if (tmp177.Value != null)
					{
						s.AddRange(tmp177.Value.Serialize());
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize CArea
			byte tmp178;
			tmp178 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp178 == 1)
			{
				byte tmp179;
				tmp179 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp180 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp180, 0, tmp179);
				offset += tmp179;
				uint tmp181;
				tmp181 = BitConverter.ToUInt32(tmp180, (int)0);
				
				CArea = new List<ECell?>();
				for (uint tmp182 = 0; tmp182 < tmp181; tmp182++)
				{
					ECell? tmp183;
					byte tmp184;
					tmp184 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp184 == 1)
					{
						sbyte tmp185;
						tmp185 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp183 = (ECell)tmp185;
					}
					else
						tmp183 = null;
					CArea.Add(tmp183);
				}
			}
			else
				CArea = null;
			
			// deserialize Agents
			byte tmp186;
			tmp186 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp186 == 1)
			{
				byte tmp187;
				tmp187 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp188 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp188, 0, tmp187);
				offset += tmp187;
				uint tmp189;
				tmp189 = BitConverter.ToUInt32(tmp188, (int)0);
				
				Agents = new Dictionary<AgentType?, Agent>();
				for (uint tmp190 = 0; tmp190 < tmp189; tmp190++)
				{
					AgentType? tmp191;
					byte tmp193;
					tmp193 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp193 == 1)
					{
						sbyte tmp194;
						tmp194 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp191 = (AgentType)tmp194;
					}
					else
						tmp191 = null;
					
					Agent tmp192;
					byte tmp195;
					tmp195 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp195 == 1)
					{
						tmp192 = new Agent();
						offset = tmp192.Deserialize(s, offset);
					}
					else
						tmp192 = null;
					
					Agents[tmp191] = tmp192;
				}
			}
			else
				Agents = null;
			
			// deserialize FrontlineDeliveries
			byte tmp196;
			tmp196 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp196 == 1)
			{
				byte tmp197;
				tmp197 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp198 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp198, 0, tmp197);
				offset += tmp197;
				uint tmp199;
				tmp199 = BitConverter.ToUInt32(tmp198, (int)0);
				
				FrontlineDeliveries = new List<FrontlineDelivery>();
				for (uint tmp200 = 0; tmp200 < tmp199; tmp200++)
				{
					FrontlineDelivery tmp201;
					byte tmp202;
					tmp202 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp202 == 1)
					{
						tmp201 = new FrontlineDelivery();
						offset = tmp201.Deserialize(s, offset);
					}
					else
						tmp201 = null;
					FrontlineDeliveries.Add(tmp201);
				}
			}
			else
				FrontlineDeliveries = null;
			
			// deserialize Warehouse
			byte tmp203;
			tmp203 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp203 == 1)
			{
				Warehouse = new Warehouse();
				offset = Warehouse.Deserialize(s, offset);
			}
			else
				Warehouse = null;
			
			// deserialize BacklineDelivery
			byte tmp204;
			tmp204 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp204 == 1)
			{
				BacklineDelivery = new BacklineDelivery();
				offset = BacklineDelivery.Deserialize(s, offset);
			}
			else
				BacklineDelivery = null;
			
			// deserialize Factory
			byte tmp205;
			tmp205 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp205 == 1)
			{
				Factory = new Factory();
				offset = Factory.Deserialize(s, offset);
			}
			else
				Factory = null;
			
			// deserialize Units
			byte tmp206;
			tmp206 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp206 == 1)
			{
				byte tmp207;
				tmp207 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp208 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp208, 0, tmp207);
				offset += tmp207;
				uint tmp209;
				tmp209 = BitConverter.ToUInt32(tmp208, (int)0);
				
				Units = new Dictionary<UnitType?, Unit>();
				for (uint tmp210 = 0; tmp210 < tmp209; tmp210++)
				{
					UnitType? tmp211;
					byte tmp213;
					tmp213 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp213 == 1)
					{
						sbyte tmp214;
						tmp214 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp211 = (UnitType)tmp214;
					}
					else
						tmp211 = null;
					
					Unit tmp212;
					byte tmp215;
					tmp215 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp215 == 1)
					{
						tmp212 = new Unit();
						offset = tmp212.Deserialize(s, offset);
					}
					else
						tmp212 = null;
					
					Units[tmp211] = tmp212;
				}
			}
			else
				Units = null;
			
			return offset;
		}
	}
	
	public partial class World : KSObject
	{
		public int? MaxCycles { get; set; }
		public Dictionary<string, Base> Bases { get; set; }
		public Dictionary<string, int?> TotalHealths { get; set; }
		

		public World()
		{
		}
		
		public new const string NameStatic = "World";
		
		public override string Name() => "World";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize MaxCycles
			s.Add((byte)((MaxCycles == null) ? 0 : 1));
			if (MaxCycles != null)
			{
				s.AddRange(BitConverter.GetBytes((int)MaxCycles));
			}
			
			// serialize Bases
			s.Add((byte)((Bases == null) ? 0 : 1));
			if (Bases != null)
			{
				List<byte> tmp216 = new List<byte>();
				tmp216.AddRange(BitConverter.GetBytes((uint)Bases.Count()));
				while (tmp216.Count > 0 && tmp216.Last() == 0)
					tmp216.RemoveAt(tmp216.Count - 1);
				s.Add((byte)tmp216.Count);
				s.AddRange(tmp216);
				
				foreach (var tmp217 in Bases)
				{
					s.Add((byte)((tmp217.Key == null) ? 0 : 1));
					if (tmp217.Key != null)
					{
						List<byte> tmp218 = new List<byte>();
						tmp218.AddRange(BitConverter.GetBytes((uint)tmp217.Key.Count()));
						while (tmp218.Count > 0 && tmp218.Last() == 0)
							tmp218.RemoveAt(tmp218.Count - 1);
						s.Add((byte)tmp218.Count);
						s.AddRange(tmp218);
						
						s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(tmp217.Key));
					}
					
					s.Add((byte)((tmp217.Value == null) ? 0 : 1));
					if (tmp217.Value != null)
					{
						s.AddRange(tmp217.Value.Serialize());
					}
				}
			}
			
			// serialize TotalHealths
			s.Add((byte)((TotalHealths == null) ? 0 : 1));
			if (TotalHealths != null)
			{
				List<byte> tmp219 = new List<byte>();
				tmp219.AddRange(BitConverter.GetBytes((uint)TotalHealths.Count()));
				while (tmp219.Count > 0 && tmp219.Last() == 0)
					tmp219.RemoveAt(tmp219.Count - 1);
				s.Add((byte)tmp219.Count);
				s.AddRange(tmp219);
				
				foreach (var tmp220 in TotalHealths)
				{
					s.Add((byte)((tmp220.Key == null) ? 0 : 1));
					if (tmp220.Key != null)
					{
						List<byte> tmp221 = new List<byte>();
						tmp221.AddRange(BitConverter.GetBytes((uint)tmp220.Key.Count()));
						while (tmp221.Count > 0 && tmp221.Last() == 0)
							tmp221.RemoveAt(tmp221.Count - 1);
						s.Add((byte)tmp221.Count);
						s.AddRange(tmp221);
						
						s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(tmp220.Key));
					}
					
					s.Add((byte)((tmp220.Value == null) ? 0 : 1));
					if (tmp220.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp220.Value));
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize MaxCycles
			byte tmp222;
			tmp222 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp222 == 1)
			{
				MaxCycles = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				MaxCycles = null;
			
			// deserialize Bases
			byte tmp223;
			tmp223 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp223 == 1)
			{
				byte tmp224;
				tmp224 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp225 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp225, 0, tmp224);
				offset += tmp224;
				uint tmp226;
				tmp226 = BitConverter.ToUInt32(tmp225, (int)0);
				
				Bases = new Dictionary<string, Base>();
				for (uint tmp227 = 0; tmp227 < tmp226; tmp227++)
				{
					string tmp228;
					byte tmp230;
					tmp230 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp230 == 1)
					{
						byte tmp231;
						tmp231 = (byte)s[(int)offset];
						offset += sizeof(byte);
						byte[] tmp232 = new byte[sizeof(uint)];
						Array.Copy(s, offset, tmp232, 0, tmp231);
						offset += tmp231;
						uint tmp233;
						tmp233 = BitConverter.ToUInt32(tmp232, (int)0);
						
						tmp228 = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp233).ToArray());
						offset += tmp233;
					}
					else
						tmp228 = null;
					
					Base tmp229;
					byte tmp234;
					tmp234 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp234 == 1)
					{
						tmp229 = new Base();
						offset = tmp229.Deserialize(s, offset);
					}
					else
						tmp229 = null;
					
					Bases[tmp228] = tmp229;
				}
			}
			else
				Bases = null;
			
			// deserialize TotalHealths
			byte tmp235;
			tmp235 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp235 == 1)
			{
				byte tmp236;
				tmp236 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp237 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp237, 0, tmp236);
				offset += tmp236;
				uint tmp238;
				tmp238 = BitConverter.ToUInt32(tmp237, (int)0);
				
				TotalHealths = new Dictionary<string, int?>();
				for (uint tmp239 = 0; tmp239 < tmp238; tmp239++)
				{
					string tmp240;
					byte tmp242;
					tmp242 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp242 == 1)
					{
						byte tmp243;
						tmp243 = (byte)s[(int)offset];
						offset += sizeof(byte);
						byte[] tmp244 = new byte[sizeof(uint)];
						Array.Copy(s, offset, tmp244, 0, tmp243);
						offset += tmp243;
						uint tmp245;
						tmp245 = BitConverter.ToUInt32(tmp244, (int)0);
						
						tmp240 = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp245).ToArray());
						offset += tmp245;
					}
					else
						tmp240 = null;
					
					int? tmp241;
					byte tmp246;
					tmp246 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp246 == 1)
					{
						tmp241 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp241 = null;
					
					TotalHealths[tmp240] = tmp241;
				}
			}
			else
				TotalHealths = null;
			
			return offset;
		}
	}
} // namespace KS.Models
