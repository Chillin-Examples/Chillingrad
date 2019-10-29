using System;
using System.Linq;
using System.Collections.Generic;

namespace KS.Commands
{
	public enum CommandMaterialType
	{
		Powder = 0,
		Steel = 1,
		Aluminum = 2,
		Shell = 3,
		Nickel = 4,
		Manganese = 5,
		Chromium = 6,
	}
	
	public enum CommandAmmoType
	{
		RifleBullet = 0,
		TankShell = 1,
		Bomb = 2,
		ArtilleryShell = 3,
		HMGBullet = 4,
	}
	
	public enum CommandAgentType
	{
		Warehouse = 0,
		Factory = 1,
	}
	
	public partial class BaseCommand : KSObject
	{
		public CommandAgentType? AgentType { get; set; }
		

		public BaseCommand()
		{
		}
		
		public new const string NameStatic = "BaseCommand";
		
		public override string Name() => "BaseCommand";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize AgentType
			s.Add((byte)((AgentType == null) ? 0 : 1));
			if (AgentType != null)
			{
				s.Add((byte)((sbyte)AgentType));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize AgentType
			byte tmp0;
			tmp0 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp0 == 1)
			{
				sbyte tmp1;
				tmp1 = (sbyte)s[(int)offset];
				offset += sizeof(sbyte);
				AgentType = (CommandAgentType)tmp1;
			}
			else
				AgentType = null;
			
			return offset;
		}
	}
	
	public partial class Move : BaseCommand
	{
		public bool? Forward { get; set; }
		

		public Move()
		{
		}
		
		public new const string NameStatic = "Move";
		
		public override string Name() => "Move";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize parents
			s.AddRange(base.Serialize());
			
			// serialize Forward
			s.Add((byte)((Forward == null) ? 0 : 1));
			if (Forward != null)
			{
				s.AddRange(BitConverter.GetBytes((bool)Forward));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize parents
			offset = base.Deserialize(s, offset);
			
			// deserialize Forward
			byte tmp2;
			tmp2 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp2 == 1)
			{
				Forward = BitConverter.ToBoolean(s, (int)offset);
				offset += sizeof(bool);
			}
			else
				Forward = null;
			
			return offset;
		}
	}
	
	public partial class PickMaterial : BaseCommand
	{
		public Dictionary<CommandMaterialType?, int?> Materials { get; set; }
		

		public PickMaterial()
		{
		}
		
		public new const string NameStatic = "PickMaterial";
		
		public override string Name() => "PickMaterial";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize parents
			s.AddRange(base.Serialize());
			
			// serialize Materials
			s.Add((byte)((Materials == null) ? 0 : 1));
			if (Materials != null)
			{
				List<byte> tmp3 = new List<byte>();
				tmp3.AddRange(BitConverter.GetBytes((uint)Materials.Count()));
				while (tmp3.Count > 0 && tmp3.Last() == 0)
					tmp3.RemoveAt(tmp3.Count - 1);
				s.Add((byte)tmp3.Count);
				s.AddRange(tmp3);
				
				foreach (var tmp4 in Materials)
				{
					s.Add((byte)((tmp4.Key == null) ? 0 : 1));
					if (tmp4.Key != null)
					{
						s.Add((byte)((sbyte)tmp4.Key));
					}
					
					s.Add((byte)((tmp4.Value == null) ? 0 : 1));
					if (tmp4.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp4.Value));
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize parents
			offset = base.Deserialize(s, offset);
			
			// deserialize Materials
			byte tmp5;
			tmp5 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp5 == 1)
			{
				byte tmp6;
				tmp6 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp7 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp7, 0, tmp6);
				offset += tmp6;
				uint tmp8;
				tmp8 = BitConverter.ToUInt32(tmp7, (int)0);
				
				Materials = new Dictionary<CommandMaterialType?, int?>();
				for (uint tmp9 = 0; tmp9 < tmp8; tmp9++)
				{
					CommandMaterialType? tmp10;
					byte tmp12;
					tmp12 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp12 == 1)
					{
						sbyte tmp13;
						tmp13 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp10 = (CommandMaterialType)tmp13;
					}
					else
						tmp10 = null;
					
					int? tmp11;
					byte tmp14;
					tmp14 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp14 == 1)
					{
						tmp11 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp11 = null;
					
					Materials[tmp10] = tmp11;
				}
			}
			else
				Materials = null;
			
			return offset;
		}
	}
	
	public partial class PutMaterial : BaseCommand
	{
		public Dictionary<CommandMaterialType?, int?> Materials { get; set; }
		

		public PutMaterial()
		{
		}
		
		public new const string NameStatic = "PutMaterial";
		
		public override string Name() => "PutMaterial";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize parents
			s.AddRange(base.Serialize());
			
			// serialize Materials
			s.Add((byte)((Materials == null) ? 0 : 1));
			if (Materials != null)
			{
				List<byte> tmp15 = new List<byte>();
				tmp15.AddRange(BitConverter.GetBytes((uint)Materials.Count()));
				while (tmp15.Count > 0 && tmp15.Last() == 0)
					tmp15.RemoveAt(tmp15.Count - 1);
				s.Add((byte)tmp15.Count);
				s.AddRange(tmp15);
				
				foreach (var tmp16 in Materials)
				{
					s.Add((byte)((tmp16.Key == null) ? 0 : 1));
					if (tmp16.Key != null)
					{
						s.Add((byte)((sbyte)tmp16.Key));
					}
					
					s.Add((byte)((tmp16.Value == null) ? 0 : 1));
					if (tmp16.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp16.Value));
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize parents
			offset = base.Deserialize(s, offset);
			
			// deserialize Materials
			byte tmp17;
			tmp17 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp17 == 1)
			{
				byte tmp18;
				tmp18 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp19 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp19, 0, tmp18);
				offset += tmp18;
				uint tmp20;
				tmp20 = BitConverter.ToUInt32(tmp19, (int)0);
				
				Materials = new Dictionary<CommandMaterialType?, int?>();
				for (uint tmp21 = 0; tmp21 < tmp20; tmp21++)
				{
					CommandMaterialType? tmp22;
					byte tmp24;
					tmp24 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp24 == 1)
					{
						sbyte tmp25;
						tmp25 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp22 = (CommandMaterialType)tmp25;
					}
					else
						tmp22 = null;
					
					int? tmp23;
					byte tmp26;
					tmp26 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp26 == 1)
					{
						tmp23 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp23 = null;
					
					Materials[tmp22] = tmp23;
				}
			}
			else
				Materials = null;
			
			return offset;
		}
	}
	
	public partial class PickAmmo : BaseCommand
	{
		public Dictionary<CommandAmmoType?, int?> Ammos { get; set; }
		

		public PickAmmo()
		{
		}
		
		public new const string NameStatic = "PickAmmo";
		
		public override string Name() => "PickAmmo";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize parents
			s.AddRange(base.Serialize());
			
			// serialize Ammos
			s.Add((byte)((Ammos == null) ? 0 : 1));
			if (Ammos != null)
			{
				List<byte> tmp27 = new List<byte>();
				tmp27.AddRange(BitConverter.GetBytes((uint)Ammos.Count()));
				while (tmp27.Count > 0 && tmp27.Last() == 0)
					tmp27.RemoveAt(tmp27.Count - 1);
				s.Add((byte)tmp27.Count);
				s.AddRange(tmp27);
				
				foreach (var tmp28 in Ammos)
				{
					s.Add((byte)((tmp28.Key == null) ? 0 : 1));
					if (tmp28.Key != null)
					{
						s.Add((byte)((sbyte)tmp28.Key));
					}
					
					s.Add((byte)((tmp28.Value == null) ? 0 : 1));
					if (tmp28.Value != null)
					{
						s.AddRange(BitConverter.GetBytes((int)tmp28.Value));
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize parents
			offset = base.Deserialize(s, offset);
			
			// deserialize Ammos
			byte tmp29;
			tmp29 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp29 == 1)
			{
				byte tmp30;
				tmp30 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp31 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp31, 0, tmp30);
				offset += tmp30;
				uint tmp32;
				tmp32 = BitConverter.ToUInt32(tmp31, (int)0);
				
				Ammos = new Dictionary<CommandAmmoType?, int?>();
				for (uint tmp33 = 0; tmp33 < tmp32; tmp33++)
				{
					CommandAmmoType? tmp34;
					byte tmp36;
					tmp36 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp36 == 1)
					{
						sbyte tmp37;
						tmp37 = (sbyte)s[(int)offset];
						offset += sizeof(sbyte);
						tmp34 = (CommandAmmoType)tmp37;
					}
					else
						tmp34 = null;
					
					int? tmp35;
					byte tmp38;
					tmp38 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp38 == 1)
					{
						tmp35 = BitConverter.ToInt32(s, (int)offset);
						offset += sizeof(int);
					}
					else
						tmp35 = null;
					
					Ammos[tmp34] = tmp35;
				}
			}
			else
				Ammos = null;
			
			return offset;
		}
	}
	
	public partial class PutAmmo : BaseCommand
	{
		

		public PutAmmo()
		{
		}
		
		public new const string NameStatic = "PutAmmo";
		
		public override string Name() => "PutAmmo";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize parents
			s.AddRange(base.Serialize());
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize parents
			offset = base.Deserialize(s, offset);
			
			return offset;
		}
	}
} // namespace KS.Commands
