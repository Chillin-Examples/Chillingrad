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
		public bool? IsAvailable { get; set; }
		public Dictionary<AmmoType?, int?> Ammos { get; set; }
		public int? TruckDeliveryRemTime { get; set; }
		public int? CTruckDeliveryDuration { get; set; }
		public int? TruckReturnRemTime { get; set; }
		public int? CTruckReturnDuration { get; set; }
		

		public FrontlineDelivery()
		{
		}
		
		public new const string NameStatic = "FrontlineDelivery";
		
		public override string Name() => "FrontlineDelivery";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize IsAvailable
			s.Add((byte)((IsAvailable == null) ? 0 : 1));
			if (IsAvailable != null)
			{
				s.AddRange(BitConverter.GetBytes((bool)IsAvailable));
			}
			
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
			
			// serialize TruckDeliveryRemTime
			s.Add((byte)((TruckDeliveryRemTime == null) ? 0 : 1));
			if (TruckDeliveryRemTime != null)
			{
				s.AddRange(BitConverter.GetBytes((int)TruckDeliveryRemTime));
			}
			
			// serialize CTruckDeliveryDuration
			s.Add((byte)((CTruckDeliveryDuration == null) ? 0 : 1));
			if (CTruckDeliveryDuration != null)
			{
				s.AddRange(BitConverter.GetBytes((int)CTruckDeliveryDuration));
			}
			
			// serialize TruckReturnRemTime
			s.Add((byte)((TruckReturnRemTime == null) ? 0 : 1));
			if (TruckReturnRemTime != null)
			{
				s.AddRange(BitConverter.GetBytes((int)TruckReturnRemTime));
			}
			
			// serialize CTruckReturnDuration
			s.Add((byte)((CTruckReturnDuration == null) ? 0 : 1));
			if (CTruckReturnDuration != null)
			{
				s.AddRange(BitConverter.GetBytes((int)CTruckReturnDuration));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize IsAvailable
			byte tmp14;
			tmp14 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp14 == 1)
			{
				IsAvailable = BitConverter.ToBoolean(s, (int)offset);
				offset += sizeof(bool);
			}
			else
				IsAvailable = null;
			
			// deserialize Ammos
			byte tmp15;
			tmp15 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp15 == 1)
			{
				byte tmp16;
				tmp16 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp17 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp17, 0, tmp16);
				offset += tmp16;
				uint tmp18;
				tmp18 = BitConverter.ToUInt32(tmp17, (int)0);
				
				Ammos = new Dictionary<AmmoType?, int?>();
				for (uint tmp19 = 0; tmp19 < tmp18; tmp19++)
				{
					AmmoType? tmp20;
					byte tmp22;
					tmp22 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp22 == 1)
					{
						sbyte tmp23;
						tmp23 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp20 = (AmmoType)tmp23;
					}
					else
						tmp20 = null;
					
					int? tmp21;
					byte tmp24;
					tmp24 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp24 == 1)
					{
						tmp21 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp21 = null;
					
					Ammos[tmp20] = tmp21;
				}
			}
			else
				Ammos = null;
			
			// deserialize TruckDeliveryRemTime
			byte tmp25;
			tmp25 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp25 == 1)
			{
				TruckDeliveryRemTime = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				TruckDeliveryRemTime = null;
			
			// deserialize CTruckDeliveryDuration
			byte tmp26;
			tmp26 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp26 == 1)
			{
				CTruckDeliveryDuration = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				CTruckDeliveryDuration = null;
			
			// deserialize TruckReturnRemTime
			byte tmp27;
			tmp27 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp27 == 1)
			{
				TruckReturnRemTime = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				TruckReturnRemTime = null;
			
			// deserialize CTruckReturnDuration
			byte tmp28;
			tmp28 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp28 == 1)
			{
				CTruckReturnDuration = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				CTruckReturnDuration = null;
			
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
				List<byte> tmp29 = new List<byte>();
				tmp29.AddRange(BitConverter.GetBytes((uint)Materials.Count()));
				while (tmp29.Count > 0 && tmp29.Last() == 0)
					tmp29.RemoveAt(tmp29.Count - 1);
				s.Add((byte)tmp29.Count);
				s.AddRange(tmp29);
				
				foreach (var tmp30 in Materials)
				{
					s.Add((byte)((tmp30.Key == null) ? 0 : 1));
					if (tmp30.Key != null)
					{
						s.AddRange(tmp30.Key.Serialize());
					}
					
					s.Add((byte)((tmp30.Value == null) ? 0 : 1));
					if (tmp30.Value != null)
					{
						s.AddRange(tmp30.Value.Serialize());
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
			byte tmp31;
			tmp31 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp31 == 1)
			{
				byte tmp32;
				tmp32 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp33 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp33, 0, tmp32);
				offset += tmp32;
				uint tmp34;
				tmp34 = BitConverter.ToUInt32(tmp33, (int)0);
				
				Materials = new Dictionary<Position, Material>();
				for (uint tmp35 = 0; tmp35 < tmp34; tmp35++)
				{
					Position tmp36;
					byte tmp38;
					tmp38 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp38 == 1)
					{
						tmp36 = new Position();
						offset = tmp36.Deserialize(s, offset);
					}
					else
						tmp36 = null;
					
					Material tmp37;
					byte tmp39;
					tmp39 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp39 == 1)
					{
						tmp37 = new Material();
						offset = tmp37.Deserialize(s, offset);
					}
					else
						tmp37 = null;
					
					Materials[tmp36] = tmp37;
				}
			}
			else
				Materials = null;
			
			// deserialize MaterialsReloadRemTime
			byte tmp40;
			tmp40 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp40 == 1)
			{
				MaterialsReloadRemTime = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				MaterialsReloadRemTime = null;
			
			// deserialize CMaterialsReloadDuration
			byte tmp41;
			tmp41 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp41 == 1)
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
				List<byte> tmp42 = new List<byte>();
				tmp42.AddRange(BitConverter.GetBytes((uint)Materials.Count()));
				while (tmp42.Count > 0 && tmp42.Last() == 0)
					tmp42.RemoveAt(tmp42.Count - 1);
				s.Add((byte)tmp42.Count);
				s.AddRange(tmp42);
				
				foreach (var tmp43 in Materials)
				{
					s.Add((byte)((tmp43.Key == null) ? 0 : 1));
					if (tmp43.Key != null)
					{
						s.Add((byte)((sbyte)tmp43.Key));
					}
					
					s.Add((byte)((tmp43.Value == null) ? 0 : 1));
					if (tmp43.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp43.Value));
					}
				}
			}
			
			// serialize Ammos
			s.Add((byte)((Ammos == null) ? 0 : 1));
			if (Ammos != null)
			{
				List<byte> tmp44 = new List<byte>();
				tmp44.AddRange(BitConverter.GetBytes((uint)Ammos.Count()));
				while (tmp44.Count > 0 && tmp44.Last() == 0)
					tmp44.RemoveAt(tmp44.Count - 1);
				s.Add((byte)tmp44.Count);
				s.AddRange(tmp44);
				
				foreach (var tmp45 in Ammos)
				{
					s.Add((byte)((tmp45.Key == null) ? 0 : 1));
					if (tmp45.Key != null)
					{
						s.Add((byte)((sbyte)tmp45.Key));
					}
					
					s.Add((byte)((tmp45.Value == null) ? 0 : 1));
					if (tmp45.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp45.Value));
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Materials
			byte tmp46;
			tmp46 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp46 == 1)
			{
				byte tmp47;
				tmp47 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp48 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp48, 0, tmp47);
				offset += tmp47;
				uint tmp49;
				tmp49 = BitConverter.ToUInt32(tmp48, (int)0);
				
				Materials = new Dictionary<MaterialType?, int?>();
				for (uint tmp50 = 0; tmp50 < tmp49; tmp50++)
				{
					MaterialType? tmp51;
					byte tmp53;
					tmp53 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp53 == 1)
					{
						sbyte tmp54;
						tmp54 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp51 = (MaterialType)tmp54;
					}
					else
						tmp51 = null;
					
					int? tmp52;
					byte tmp55;
					tmp55 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp55 == 1)
					{
						tmp52 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp52 = null;
					
					Materials[tmp51] = tmp52;
				}
			}
			else
				Materials = null;
			
			// deserialize Ammos
			byte tmp56;
			tmp56 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp56 == 1)
			{
				byte tmp57;
				tmp57 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp58 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp58, 0, tmp57);
				offset += tmp57;
				uint tmp59;
				tmp59 = BitConverter.ToUInt32(tmp58, (int)0);
				
				Ammos = new Dictionary<AmmoType?, int?>();
				for (uint tmp60 = 0; tmp60 < tmp59; tmp60++)
				{
					AmmoType? tmp61;
					byte tmp63;
					tmp63 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp63 == 1)
					{
						sbyte tmp64;
						tmp64 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp61 = (AmmoType)tmp64;
					}
					else
						tmp61 = null;
					
					int? tmp62;
					byte tmp65;
					tmp65 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp65 == 1)
					{
						tmp62 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp62 = null;
					
					Ammos[tmp61] = tmp62;
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
				List<byte> tmp66 = new List<byte>();
				tmp66.AddRange(BitConverter.GetBytes((uint)Machines.Count()));
				while (tmp66.Count > 0 && tmp66.Last() == 0)
					tmp66.RemoveAt(tmp66.Count - 1);
				s.Add((byte)tmp66.Count);
				s.AddRange(tmp66);
				
				foreach (var tmp67 in Machines)
				{
					s.Add((byte)((tmp67.Key == null) ? 0 : 1));
					if (tmp67.Key != null)
					{
						s.AddRange(tmp67.Key.Serialize());
					}
					
					s.Add((byte)((tmp67.Value == null) ? 0 : 1));
					if (tmp67.Value != null)
					{
						s.AddRange(tmp67.Value.Serialize());
					}
				}
			}
			
			// serialize CMixtureFormulas
			s.Add((byte)((CMixtureFormulas == null) ? 0 : 1));
			if (CMixtureFormulas != null)
			{
				List<byte> tmp68 = new List<byte>();
				tmp68.AddRange(BitConverter.GetBytes((uint)CMixtureFormulas.Count()));
				while (tmp68.Count > 0 && tmp68.Last() == 0)
					tmp68.RemoveAt(tmp68.Count - 1);
				s.Add((byte)tmp68.Count);
				s.AddRange(tmp68);
				
				foreach (var tmp69 in CMixtureFormulas)
				{
					s.Add((byte)((tmp69.Key == null) ? 0 : 1));
					if (tmp69.Key != null)
					{
						s.Add((byte)((sbyte)tmp69.Key));
					}
					
					s.Add((byte)((tmp69.Value == null) ? 0 : 1));
					if (tmp69.Value != null)
					{
						List<byte> tmp70 = new List<byte>();
						tmp70.AddRange(BitConverter.GetBytes((uint)tmp69.Value.Count()));
						while (tmp70.Count > 0 && tmp70.Last() == 0)
							tmp70.RemoveAt(tmp70.Count - 1);
						s.Add((byte)tmp70.Count);
						s.AddRange(tmp70);
						
						foreach (var tmp71 in tmp69.Value)
						{
							s.Add((byte)((tmp71.Key == null) ? 0 : 1));
							if (tmp71.Key != null)
							{
								s.Add((byte)((sbyte)tmp71.Key));
							}
							
							s.Add((byte)((tmp71.Value == null) ? 0 : 1));
							if (tmp71.Value != null)
							{
								s.AddRange(BitConverter.GetBytes((int)tmp71.Value));
							}
						}
					}
				}
			}
			
			// serialize CConstructionDurations
			s.Add((byte)((CConstructionDurations == null) ? 0 : 1));
			if (CConstructionDurations != null)
			{
				List<byte> tmp72 = new List<byte>();
				tmp72.AddRange(BitConverter.GetBytes((uint)CConstructionDurations.Count()));
				while (tmp72.Count > 0 && tmp72.Last() == 0)
					tmp72.RemoveAt(tmp72.Count - 1);
				s.Add((byte)tmp72.Count);
				s.AddRange(tmp72);
				
				foreach (var tmp73 in CConstructionDurations)
				{
					s.Add((byte)((tmp73.Key == null) ? 0 : 1));
					if (tmp73.Key != null)
					{
						s.Add((byte)((sbyte)tmp73.Key));
					}
					
					s.Add((byte)((tmp73.Value == null) ? 0 : 1));
					if (tmp73.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp73.Value));
					}
				}
			}
			
			// serialize CAmmoBoxSizes
			s.Add((byte)((CAmmoBoxSizes == null) ? 0 : 1));
			if (CAmmoBoxSizes != null)
			{
				List<byte> tmp74 = new List<byte>();
				tmp74.AddRange(BitConverter.GetBytes((uint)CAmmoBoxSizes.Count()));
				while (tmp74.Count > 0 && tmp74.Last() == 0)
					tmp74.RemoveAt(tmp74.Count - 1);
				s.Add((byte)tmp74.Count);
				s.AddRange(tmp74);
				
				foreach (var tmp75 in CAmmoBoxSizes)
				{
					s.Add((byte)((tmp75.Key == null) ? 0 : 1));
					if (tmp75.Key != null)
					{
						s.Add((byte)((sbyte)tmp75.Key));
					}
					
					s.Add((byte)((tmp75.Value == null) ? 0 : 1));
					if (tmp75.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp75.Value));
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Machines
			byte tmp76;
			tmp76 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp76 == 1)
			{
				byte tmp77;
				tmp77 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp78 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp78, 0, tmp77);
				offset += tmp77;
				uint tmp79;
				tmp79 = BitConverter.ToUInt32(tmp78, (int)0);
				
				Machines = new Dictionary<Position, Machine>();
				for (uint tmp80 = 0; tmp80 < tmp79; tmp80++)
				{
					Position tmp81;
					byte tmp83;
					tmp83 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp83 == 1)
					{
						tmp81 = new Position();
						offset = tmp81.Deserialize(s, offset);
					}
					else
						tmp81 = null;
					
					Machine tmp82;
					byte tmp84;
					tmp84 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp84 == 1)
					{
						tmp82 = new Machine();
						offset = tmp82.Deserialize(s, offset);
					}
					else
						tmp82 = null;
					
					Machines[tmp81] = tmp82;
				}
			}
			else
				Machines = null;
			
			// deserialize CMixtureFormulas
			byte tmp85;
			tmp85 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp85 == 1)
			{
				byte tmp86;
				tmp86 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp87 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp87, 0, tmp86);
				offset += tmp86;
				uint tmp88;
				tmp88 = BitConverter.ToUInt32(tmp87, (int)0);
				
				CMixtureFormulas = new Dictionary<AmmoType?, Dictionary<MaterialType?, int?>>();
				for (uint tmp89 = 0; tmp89 < tmp88; tmp89++)
				{
					AmmoType? tmp90;
					byte tmp92;
					tmp92 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp92 == 1)
					{
						sbyte tmp93;
						tmp93 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp90 = (AmmoType)tmp93;
					}
					else
						tmp90 = null;
					
					Dictionary<MaterialType?, int?> tmp91;
					byte tmp94;
					tmp94 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp94 == 1)
					{
						byte tmp95;
						tmp95 = (byte)s[(int)offset];
						offset += sizeof(byte);
						byte[] tmp96 = new byte[sizeof(uint)];
						Array.Copy(s, offset, tmp96, 0, tmp95);
						offset += tmp95;
						uint tmp97;
						tmp97 = BitConverter.ToUInt32(tmp96, (int)0);
						
						tmp91 = new Dictionary<MaterialType?, int?>();
						for (uint tmp98 = 0; tmp98 < tmp97; tmp98++)
						{
							MaterialType? tmp99;
							byte tmp101;
							tmp101 = (byte)s[(int)offset];
							offset += sizeof(byte);
							if (tmp101 == 1)
							{
								sbyte tmp102;
								tmp102 = (sbyte)s[(int)offset];
								offset += sizeof(sbyte);
								tmp99 = (MaterialType)tmp102;
							}
							else
								tmp99 = null;
							
							int? tmp100;
							byte tmp103;
							tmp103 = (byte)s[(int)offset];
							offset += sizeof(byte);
							if (tmp103 == 1)
							{
								tmp100 = BitConverter.ToInt32(s, (int)offset);
								offset += sizeof(int);
							}
							else
								tmp100 = null;
							
							tmp91[tmp99] = tmp100;
						}
					}
					else
						tmp91 = null;
					
					CMixtureFormulas[tmp90] = tmp91;
				}
			}
			else
				CMixtureFormulas = null;
			
			// deserialize CConstructionDurations
			byte tmp104;
			tmp104 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp104 == 1)
			{
				byte tmp105;
				tmp105 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp106 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp106, 0, tmp105);
				offset += tmp105;
				uint tmp107;
				tmp107 = BitConverter.ToUInt32(tmp106, (int)0);
				
				CConstructionDurations = new Dictionary<AmmoType?, int?>();
				for (uint tmp108 = 0; tmp108 < tmp107; tmp108++)
				{
					AmmoType? tmp109;
					byte tmp111;
					tmp111 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp111 == 1)
					{
						sbyte tmp112;
						tmp112 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp109 = (AmmoType)tmp112;
					}
					else
						tmp109 = null;
					
					int? tmp110;
					byte tmp113;
					tmp113 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp113 == 1)
					{
						tmp110 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp110 = null;
					
					CConstructionDurations[tmp109] = tmp110;
				}
			}
			else
				CConstructionDurations = null;
			
			// deserialize CAmmoBoxSizes
			byte tmp114;
			tmp114 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp114 == 1)
			{
				byte tmp115;
				tmp115 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp116 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp116, 0, tmp115);
				offset += tmp115;
				uint tmp117;
				tmp117 = BitConverter.ToUInt32(tmp116, (int)0);
				
				CAmmoBoxSizes = new Dictionary<AmmoType?, int?>();
				for (uint tmp118 = 0; tmp118 < tmp117; tmp118++)
				{
					AmmoType? tmp119;
					byte tmp121;
					tmp121 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp121 == 1)
					{
						sbyte tmp122;
						tmp122 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp119 = (AmmoType)tmp122;
					}
					else
						tmp119 = null;
					
					int? tmp120;
					byte tmp123;
					tmp123 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp123 == 1)
					{
						tmp120 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp120 = null;
					
					CAmmoBoxSizes[tmp119] = tmp120;
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
				List<byte> tmp124 = new List<byte>();
				tmp124.AddRange(BitConverter.GetBytes((uint)MaterialsBag.Count()));
				while (tmp124.Count > 0 && tmp124.Last() == 0)
					tmp124.RemoveAt(tmp124.Count - 1);
				s.Add((byte)tmp124.Count);
				s.AddRange(tmp124);
				
				foreach (var tmp125 in MaterialsBag)
				{
					s.Add((byte)((tmp125.Key == null) ? 0 : 1));
					if (tmp125.Key != null)
					{
						s.Add((byte)((sbyte)tmp125.Key));
					}
					
					s.Add((byte)((tmp125.Value == null) ? 0 : 1));
					if (tmp125.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp125.Value));
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
				List<byte> tmp126 = new List<byte>();
				tmp126.AddRange(BitConverter.GetBytes((uint)AmmosBag.Count()));
				while (tmp126.Count > 0 && tmp126.Last() == 0)
					tmp126.RemoveAt(tmp126.Count - 1);
				s.Add((byte)tmp126.Count);
				s.AddRange(tmp126);
				
				foreach (var tmp127 in AmmosBag)
				{
					s.Add((byte)((tmp127.Key == null) ? 0 : 1));
					if (tmp127.Key != null)
					{
						s.Add((byte)((sbyte)tmp127.Key));
					}
					
					s.Add((byte)((tmp127.Value == null) ? 0 : 1));
					if (tmp127.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp127.Value));
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
			byte tmp128;
			tmp128 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp128 == 1)
			{
				sbyte tmp129;
				tmp129 = (sbyte)s[(int)offset];
				offset += sizeof(sbyte);
				Type = (AgentType)tmp129;
			}
			else
				Type = null;
			
			// deserialize Position
			byte tmp130;
			tmp130 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp130 == 1)
			{
				Position = new Position();
				offset = Position.Deserialize(s, offset);
			}
			else
				Position = null;
			
			// deserialize MaterialsBag
			byte tmp131;
			tmp131 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp131 == 1)
			{
				byte tmp132;
				tmp132 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp133 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp133, 0, tmp132);
				offset += tmp132;
				uint tmp134;
				tmp134 = BitConverter.ToUInt32(tmp133, (int)0);
				
				MaterialsBag = new Dictionary<MaterialType?, int?>();
				for (uint tmp135 = 0; tmp135 < tmp134; tmp135++)
				{
					MaterialType? tmp136;
					byte tmp138;
					tmp138 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp138 == 1)
					{
						sbyte tmp139;
						tmp139 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp136 = (MaterialType)tmp139;
					}
					else
						tmp136 = null;
					
					int? tmp137;
					byte tmp140;
					tmp140 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp140 == 1)
					{
						tmp137 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp137 = null;
					
					MaterialsBag[tmp136] = tmp137;
				}
			}
			else
				MaterialsBag = null;
			
			// deserialize CMaterialsBagCapacity
			byte tmp141;
			tmp141 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp141 == 1)
			{
				CMaterialsBagCapacity = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				CMaterialsBagCapacity = null;
			
			// deserialize AmmosBag
			byte tmp142;
			tmp142 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp142 == 1)
			{
				byte tmp143;
				tmp143 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp144 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp144, 0, tmp143);
				offset += tmp143;
				uint tmp145;
				tmp145 = BitConverter.ToUInt32(tmp144, (int)0);
				
				AmmosBag = new Dictionary<AmmoType?, int?>();
				for (uint tmp146 = 0; tmp146 < tmp145; tmp146++)
				{
					AmmoType? tmp147;
					byte tmp149;
					tmp149 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp149 == 1)
					{
						sbyte tmp150;
						tmp150 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp147 = (AmmoType)tmp150;
					}
					else
						tmp147 = null;
					
					int? tmp148;
					byte tmp151;
					tmp151 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp151 == 1)
					{
						tmp148 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp148 = null;
					
					AmmosBag[tmp147] = tmp148;
				}
			}
			else
				AmmosBag = null;
			
			// deserialize CAmmosBagCapacity
			byte tmp152;
			tmp152 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp152 == 1)
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
				List<byte> tmp153 = new List<byte>();
				tmp153.AddRange(BitConverter.GetBytes((uint)CDamageDistribution.Count()));
				while (tmp153.Count > 0 && tmp153.Last() == 0)
					tmp153.RemoveAt(tmp153.Count - 1);
				s.Add((byte)tmp153.Count);
				s.AddRange(tmp153);
				
				foreach (var tmp154 in CDamageDistribution)
				{
					s.Add((byte)((tmp154.Key == null) ? 0 : 1));
					if (tmp154.Key != null)
					{
						s.Add((byte)((sbyte)tmp154.Key));
					}
					
					s.Add((byte)((tmp154.Value == null) ? 0 : 1));
					if (tmp154.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((float)tmp154.Value));
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
			byte tmp155;
			tmp155 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp155 == 1)
			{
				sbyte tmp156;
				tmp156 = (sbyte)s[(int)offset];
				offset += sizeof(sbyte);
				Type = (UnitType)tmp156;
			}
			else
				Type = null;
			
			// deserialize Health
			byte tmp157;
			tmp157 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp157 == 1)
			{
				Health = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				Health = null;
			
			// deserialize CIndividualHealth
			byte tmp158;
			tmp158 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp158 == 1)
			{
				CIndividualHealth = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				CIndividualHealth = null;
			
			// deserialize CIndividualDamage
			byte tmp159;
			tmp159 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp159 == 1)
			{
				CIndividualDamage = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				CIndividualDamage = null;
			
			// deserialize CDamageDistribution
			byte tmp160;
			tmp160 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp160 == 1)
			{
				byte tmp161;
				tmp161 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp162 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp162, 0, tmp161);
				offset += tmp161;
				uint tmp163;
				tmp163 = BitConverter.ToUInt32(tmp162, (int)0);
				
				CDamageDistribution = new Dictionary<UnitType?, float?>();
				for (uint tmp164 = 0; tmp164 < tmp163; tmp164++)
				{
					UnitType? tmp165;
					byte tmp167;
					tmp167 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp167 == 1)
					{
						sbyte tmp168;
						tmp168 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp165 = (UnitType)tmp168;
					}
					else
						tmp165 = null;
					
					float? tmp166;
					byte tmp169;
					tmp169 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp169 == 1)
					{
						tmp166 = BitConverter.ToSingle(s, (int)offset);
						offset += sizeof(float);
					}
					else
						tmp166 = null;
					
					CDamageDistribution[tmp165] = tmp166;
				}
			}
			else
				CDamageDistribution = null;
			
			// deserialize AmmoCount
			byte tmp170;
			tmp170 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp170 == 1)
			{
				AmmoCount = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				AmmoCount = null;
			
			// deserialize ReloadRemTime
			byte tmp171;
			tmp171 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp171 == 1)
			{
				ReloadRemTime = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				ReloadRemTime = null;
			
			// deserialize CReloadDuration
			byte tmp172;
			tmp172 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp172 == 1)
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
		public FrontlineDelivery FrontlineDelivery { get; set; }
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
				List<byte> tmp173 = new List<byte>();
				tmp173.AddRange(BitConverter.GetBytes((uint)CArea.Count()));
				while (tmp173.Count > 0 && tmp173.Last() == 0)
					tmp173.RemoveAt(tmp173.Count - 1);
				s.Add((byte)tmp173.Count);
				s.AddRange(tmp173);
				
				foreach (var tmp174 in CArea)
				{
					s.Add((byte)((tmp174 == null) ? 0 : 1));
					if (tmp174 != null)
					{
						s.Add((byte)((sbyte)tmp174));
					}
				}
			}
			
			// serialize Agents
			s.Add((byte)((Agents == null) ? 0 : 1));
			if (Agents != null)
			{
				List<byte> tmp175 = new List<byte>();
				tmp175.AddRange(BitConverter.GetBytes((uint)Agents.Count()));
				while (tmp175.Count > 0 && tmp175.Last() == 0)
					tmp175.RemoveAt(tmp175.Count - 1);
				s.Add((byte)tmp175.Count);
				s.AddRange(tmp175);
				
				foreach (var tmp176 in Agents)
				{
					s.Add((byte)((tmp176.Key == null) ? 0 : 1));
					if (tmp176.Key != null)
					{
						s.Add((byte)((sbyte)tmp176.Key));
					}
					
					s.Add((byte)((tmp176.Value == null) ? 0 : 1));
					if (tmp176.Value != null)
					{
						s.AddRange(tmp176.Value.Serialize());
					}
				}
			}
			
			// serialize FrontlineDelivery
			s.Add((byte)((FrontlineDelivery == null) ? 0 : 1));
			if (FrontlineDelivery != null)
			{
				s.AddRange(FrontlineDelivery.Serialize());
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
				List<byte> tmp177 = new List<byte>();
				tmp177.AddRange(BitConverter.GetBytes((uint)Units.Count()));
				while (tmp177.Count > 0 && tmp177.Last() == 0)
					tmp177.RemoveAt(tmp177.Count - 1);
				s.Add((byte)tmp177.Count);
				s.AddRange(tmp177);
				
				foreach (var tmp178 in Units)
				{
					s.Add((byte)((tmp178.Key == null) ? 0 : 1));
					if (tmp178.Key != null)
					{
						s.Add((byte)((sbyte)tmp178.Key));
					}
					
					s.Add((byte)((tmp178.Value == null) ? 0 : 1));
					if (tmp178.Value != null)
					{
						s.AddRange(tmp178.Value.Serialize());
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize CArea
			byte tmp179;
			tmp179 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp179 == 1)
			{
				byte tmp180;
				tmp180 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp181 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp181, 0, tmp180);
				offset += tmp180;
				uint tmp182;
				tmp182 = BitConverter.ToUInt32(tmp181, (int)0);
				
				CArea = new List<ECell?>();
				for (uint tmp183 = 0; tmp183 < tmp182; tmp183++)
				{
					ECell? tmp184;
					byte tmp185;
					tmp185 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp185 == 1)
					{
						sbyte tmp186;
						tmp186 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp184 = (ECell)tmp186;
					}
					else
						tmp184 = null;
					CArea.Add(tmp184);
				}
			}
			else
				CArea = null;
			
			// deserialize Agents
			byte tmp187;
			tmp187 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp187 == 1)
			{
				byte tmp188;
				tmp188 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp189 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp189, 0, tmp188);
				offset += tmp188;
				uint tmp190;
				tmp190 = BitConverter.ToUInt32(tmp189, (int)0);
				
				Agents = new Dictionary<AgentType?, Agent>();
				for (uint tmp191 = 0; tmp191 < tmp190; tmp191++)
				{
					AgentType? tmp192;
					byte tmp194;
					tmp194 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp194 == 1)
					{
						sbyte tmp195;
						tmp195 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp192 = (AgentType)tmp195;
					}
					else
						tmp192 = null;
					
					Agent tmp193;
					byte tmp196;
					tmp196 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp196 == 1)
					{
						tmp193 = new Agent();
						offset = tmp193.Deserialize(s, offset);
					}
					else
						tmp193 = null;
					
					Agents[tmp192] = tmp193;
				}
			}
			else
				Agents = null;
			
			// deserialize FrontlineDelivery
			byte tmp197;
			tmp197 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp197 == 1)
			{
				FrontlineDelivery = new FrontlineDelivery();
				offset = FrontlineDelivery.Deserialize(s, offset);
			}
			else
				FrontlineDelivery = null;
			
			// deserialize Warehouse
			byte tmp198;
			tmp198 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp198 == 1)
			{
				Warehouse = new Warehouse();
				offset = Warehouse.Deserialize(s, offset);
			}
			else
				Warehouse = null;
			
			// deserialize BacklineDelivery
			byte tmp199;
			tmp199 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp199 == 1)
			{
				BacklineDelivery = new BacklineDelivery();
				offset = BacklineDelivery.Deserialize(s, offset);
			}
			else
				BacklineDelivery = null;
			
			// deserialize Factory
			byte tmp200;
			tmp200 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp200 == 1)
			{
				Factory = new Factory();
				offset = Factory.Deserialize(s, offset);
			}
			else
				Factory = null;
			
			// deserialize Units
			byte tmp201;
			tmp201 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp201 == 1)
			{
				byte tmp202;
				tmp202 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp203 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp203, 0, tmp202);
				offset += tmp202;
				uint tmp204;
				tmp204 = BitConverter.ToUInt32(tmp203, (int)0);
				
				Units = new Dictionary<UnitType?, Unit>();
				for (uint tmp205 = 0; tmp205 < tmp204; tmp205++)
				{
					UnitType? tmp206;
					byte tmp208;
					tmp208 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp208 == 1)
					{
						sbyte tmp209;
						tmp209 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp206 = (UnitType)tmp209;
					}
					else
						tmp206 = null;
					
					Unit tmp207;
					byte tmp210;
					tmp210 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp210 == 1)
					{
						tmp207 = new Unit();
						offset = tmp207.Deserialize(s, offset);
					}
					else
						tmp207 = null;
					
					Units[tmp206] = tmp207;
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
				List<byte> tmp211 = new List<byte>();
				tmp211.AddRange(BitConverter.GetBytes((uint)Bases.Count()));
				while (tmp211.Count > 0 && tmp211.Last() == 0)
					tmp211.RemoveAt(tmp211.Count - 1);
				s.Add((byte)tmp211.Count);
				s.AddRange(tmp211);
				
				foreach (var tmp212 in Bases)
				{
					s.Add((byte)((tmp212.Key == null) ? 0 : 1));
					if (tmp212.Key != null)
					{
						List<byte> tmp213 = new List<byte>();
						tmp213.AddRange(BitConverter.GetBytes((uint)tmp212.Key.Count()));
						while (tmp213.Count > 0 && tmp213.Last() == 0)
							tmp213.RemoveAt(tmp213.Count - 1);
						s.Add((byte)tmp213.Count);
						s.AddRange(tmp213);
						
						s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(tmp212.Key));
					}
					
					s.Add((byte)((tmp212.Value == null) ? 0 : 1));
					if (tmp212.Value != null)
					{
						s.AddRange(tmp212.Value.Serialize());
					}
				}
			}
			
			// serialize TotalHealths
			s.Add((byte)((TotalHealths == null) ? 0 : 1));
			if (TotalHealths != null)
			{
				List<byte> tmp214 = new List<byte>();
				tmp214.AddRange(BitConverter.GetBytes((uint)TotalHealths.Count()));
				while (tmp214.Count > 0 && tmp214.Last() == 0)
					tmp214.RemoveAt(tmp214.Count - 1);
				s.Add((byte)tmp214.Count);
				s.AddRange(tmp214);
				
				foreach (var tmp215 in TotalHealths)
				{
					s.Add((byte)((tmp215.Key == null) ? 0 : 1));
					if (tmp215.Key != null)
					{
						List<byte> tmp216 = new List<byte>();
						tmp216.AddRange(BitConverter.GetBytes((uint)tmp215.Key.Count()));
						while (tmp216.Count > 0 && tmp216.Last() == 0)
							tmp216.RemoveAt(tmp216.Count - 1);
						s.Add((byte)tmp216.Count);
						s.AddRange(tmp216);
						
						s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(tmp215.Key));
					}
					
					s.Add((byte)((tmp215.Value == null) ? 0 : 1));
					if (tmp215.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp215.Value));
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize MaxCycles
			byte tmp217;
			tmp217 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp217 == 1)
			{
				MaxCycles = BitConverter.ToInt32(s, (int)offset);
				offset += sizeof(int);
			}
			else
				MaxCycles = null;
			
			// deserialize Bases
			byte tmp218;
			tmp218 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp218 == 1)
			{
				byte tmp219;
				tmp219 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp220 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp220, 0, tmp219);
				offset += tmp219;
				uint tmp221;
				tmp221 = BitConverter.ToUInt32(tmp220, (int)0);
				
				Bases = new Dictionary<string, Base>();
				for (uint tmp222 = 0; tmp222 < tmp221; tmp222++)
				{
					string tmp223;
					byte tmp225;
					tmp225 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp225 == 1)
					{
						byte tmp226;
						tmp226 = (byte)s[(int)offset];
						offset += sizeof(byte);
						byte[] tmp227 = new byte[sizeof(uint)];
						Array.Copy(s, offset, tmp227, 0, tmp226);
						offset += tmp226;
						uint tmp228;
						tmp228 = BitConverter.ToUInt32(tmp227, (int)0);
						
						tmp223 = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp228).ToArray());
						offset += tmp228;
					}
					else
						tmp223 = null;
					
					Base tmp224;
					byte tmp229;
					tmp229 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp229 == 1)
					{
						tmp224 = new Base();
						offset = tmp224.Deserialize(s, offset);
					}
					else
						tmp224 = null;
					
					Bases[tmp223] = tmp224;
				}
			}
			else
				Bases = null;
			
			// deserialize TotalHealths
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
				
				TotalHealths = new Dictionary<string, int?>();
				for (uint tmp234 = 0; tmp234 < tmp233; tmp234++)
				{
					string tmp235;
					byte tmp237;
					tmp237 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp237 == 1)
					{
						byte tmp238;
						tmp238 = (byte)s[(int)offset];
						offset += sizeof(byte);
						byte[] tmp239 = new byte[sizeof(uint)];
						Array.Copy(s, offset, tmp239, 0, tmp238);
						offset += tmp238;
						uint tmp240;
						tmp240 = BitConverter.ToUInt32(tmp239, (int)0);
						
						tmp235 = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp240).ToArray());
						offset += tmp240;
					}
					else
						tmp235 = null;
					
					int? tmp236;
					byte tmp241;
					tmp241 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp241 == 1)
					{
						tmp236 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp236 = null;
					
					TotalHealths[tmp235] = tmp236;
				}
			}
			else
				TotalHealths = null;
			
			return offset;
		}
	}
} // namespace KS.Models
