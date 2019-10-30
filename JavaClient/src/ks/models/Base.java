package ks.models;

import java.lang.*;
import java.util.*;
import java.nio.*;
import java.nio.charset.Charset;

import ks.KSObject;

public class Base extends KSObject
{
	protected List<ECell> cArea;
	protected Map<AgentType, Agent> agents;
	protected List<FrontlineDelivery> frontlineDeliveries;
	protected Warehouse warehouse;
	protected BacklineDelivery backlineDelivery;
	protected Factory factory;
	protected Map<UnitType, Unit> units;
	
	// getters
	
	public List<ECell> getCArea()
	{
		return this.cArea;
	}
	
	public Map<AgentType, Agent> getAgents()
	{
		return this.agents;
	}
	
	public List<FrontlineDelivery> getFrontlineDeliveries()
	{
		return this.frontlineDeliveries;
	}
	
	public Warehouse getWarehouse()
	{
		return this.warehouse;
	}
	
	public BacklineDelivery getBacklineDelivery()
	{
		return this.backlineDelivery;
	}
	
	public Factory getFactory()
	{
		return this.factory;
	}
	
	public Map<UnitType, Unit> getUnits()
	{
		return this.units;
	}
	
	
	// setters
	
	public void setCArea(List<ECell> cArea)
	{
		this.cArea = cArea;
	}
	
	public void setAgents(Map<AgentType, Agent> agents)
	{
		this.agents = agents;
	}
	
	public void setFrontlineDeliveries(List<FrontlineDelivery> frontlineDeliveries)
	{
		this.frontlineDeliveries = frontlineDeliveries;
	}
	
	public void setWarehouse(Warehouse warehouse)
	{
		this.warehouse = warehouse;
	}
	
	public void setBacklineDelivery(BacklineDelivery backlineDelivery)
	{
		this.backlineDelivery = backlineDelivery;
	}
	
	public void setFactory(Factory factory)
	{
		this.factory = factory;
	}
	
	public void setUnits(Map<UnitType, Unit> units)
	{
		this.units = units;
	}
	
	
	public Base()
	{
	}
	
	public static final String nameStatic = "Base";
	
	@Override
	public String name() { return "Base"; }
	
	@Override
	public byte[] serialize()
	{
		List<Byte> s = new ArrayList<>();
		
		// serialize cArea
		s.add((byte) ((cArea == null) ? 0 : 1));
		if (cArea != null)
		{
			List<Byte> tmp0 = new ArrayList<>();
			tmp0.addAll(b2B(ByteBuffer.allocate(Integer.BYTES).order(ByteOrder.LITTLE_ENDIAN).putInt(cArea.size()).array()));
			while (tmp0.size() > 0 && tmp0.get(tmp0.size() - 1) == 0)
				tmp0.remove(tmp0.size() - 1);
			s.add((byte) tmp0.size());
			s.addAll(tmp0);
			
			for (ECell tmp1 : cArea)
			{
				s.add((byte) ((tmp1 == null) ? 0 : 1));
				if (tmp1 != null)
				{
					s.add((byte) (tmp1.getValue()));
				}
			}
		}
		
		// serialize agents
		s.add((byte) ((agents == null) ? 0 : 1));
		if (agents != null)
		{
			List<Byte> tmp2 = new ArrayList<>();
			tmp2.addAll(b2B(ByteBuffer.allocate(Integer.BYTES).order(ByteOrder.LITTLE_ENDIAN).putInt(agents.size()).array()));
			while (tmp2.size() > 0 && tmp2.get(tmp2.size() - 1) == 0)
				tmp2.remove(tmp2.size() - 1);
			s.add((byte) tmp2.size());
			s.addAll(tmp2);
			
			for (Map.Entry<AgentType, Agent> tmp3 : agents.entrySet())
			{
				s.add((byte) ((tmp3.getKey() == null) ? 0 : 1));
				if (tmp3.getKey() != null)
				{
					s.add((byte) (tmp3.getKey().getValue()));
				}
				
				s.add((byte) ((tmp3.getValue() == null) ? 0 : 1));
				if (tmp3.getValue() != null)
				{
					s.addAll(b2B(tmp3.getValue().serialize()));
				}
			}
		}
		
		// serialize frontlineDeliveries
		s.add((byte) ((frontlineDeliveries == null) ? 0 : 1));
		if (frontlineDeliveries != null)
		{
			List<Byte> tmp4 = new ArrayList<>();
			tmp4.addAll(b2B(ByteBuffer.allocate(Integer.BYTES).order(ByteOrder.LITTLE_ENDIAN).putInt(frontlineDeliveries.size()).array()));
			while (tmp4.size() > 0 && tmp4.get(tmp4.size() - 1) == 0)
				tmp4.remove(tmp4.size() - 1);
			s.add((byte) tmp4.size());
			s.addAll(tmp4);
			
			for (FrontlineDelivery tmp5 : frontlineDeliveries)
			{
				s.add((byte) ((tmp5 == null) ? 0 : 1));
				if (tmp5 != null)
				{
					s.addAll(b2B(tmp5.serialize()));
				}
			}
		}
		
		// serialize warehouse
		s.add((byte) ((warehouse == null) ? 0 : 1));
		if (warehouse != null)
		{
			s.addAll(b2B(warehouse.serialize()));
		}
		
		// serialize backlineDelivery
		s.add((byte) ((backlineDelivery == null) ? 0 : 1));
		if (backlineDelivery != null)
		{
			s.addAll(b2B(backlineDelivery.serialize()));
		}
		
		// serialize factory
		s.add((byte) ((factory == null) ? 0 : 1));
		if (factory != null)
		{
			s.addAll(b2B(factory.serialize()));
		}
		
		// serialize units
		s.add((byte) ((units == null) ? 0 : 1));
		if (units != null)
		{
			List<Byte> tmp6 = new ArrayList<>();
			tmp6.addAll(b2B(ByteBuffer.allocate(Integer.BYTES).order(ByteOrder.LITTLE_ENDIAN).putInt(units.size()).array()));
			while (tmp6.size() > 0 && tmp6.get(tmp6.size() - 1) == 0)
				tmp6.remove(tmp6.size() - 1);
			s.add((byte) tmp6.size());
			s.addAll(tmp6);
			
			for (Map.Entry<UnitType, Unit> tmp7 : units.entrySet())
			{
				s.add((byte) ((tmp7.getKey() == null) ? 0 : 1));
				if (tmp7.getKey() != null)
				{
					s.add((byte) (tmp7.getKey().getValue()));
				}
				
				s.add((byte) ((tmp7.getValue() == null) ? 0 : 1));
				if (tmp7.getValue() != null)
				{
					s.addAll(b2B(tmp7.getValue().serialize()));
				}
			}
		}
		
		return B2b(s);
	}
	
	@Override
	protected int deserialize(byte[] s, int offset)
	{
		// deserialize cArea
		byte tmp8;
		tmp8 = s[offset];
		offset += Byte.BYTES;
		if (tmp8 == 1)
		{
			byte tmp9;
			tmp9 = s[offset];
			offset += Byte.BYTES;
			byte[] tmp10 = Arrays.copyOfRange(s, offset, offset + tmp9);
			offset += tmp9;
			int tmp11;
			tmp11 = ByteBuffer.wrap(Arrays.copyOfRange(tmp10, 0, 0 + Integer.BYTES)).order(ByteOrder.LITTLE_ENDIAN).getInt();
			
			cArea = new ArrayList<>();
			for (int tmp12 = 0; tmp12 < tmp11; tmp12++)
			{
				ECell tmp13;
				byte tmp14;
				tmp14 = s[offset];
				offset += Byte.BYTES;
				if (tmp14 == 1)
				{
					byte tmp15;
					tmp15 = s[offset];
					offset += Byte.BYTES;
					tmp13 = ECell.of(tmp15);
				}
				else
					tmp13 = null;
				cArea.add(tmp13);
			}
		}
		else
			cArea = null;
		
		// deserialize agents
		byte tmp16;
		tmp16 = s[offset];
		offset += Byte.BYTES;
		if (tmp16 == 1)
		{
			byte tmp17;
			tmp17 = s[offset];
			offset += Byte.BYTES;
			byte[] tmp18 = Arrays.copyOfRange(s, offset, offset + tmp17);
			offset += tmp17;
			int tmp19;
			tmp19 = ByteBuffer.wrap(Arrays.copyOfRange(tmp18, 0, 0 + Integer.BYTES)).order(ByteOrder.LITTLE_ENDIAN).getInt();
			
			agents = new HashMap<>();
			for (int tmp20 = 0; tmp20 < tmp19; tmp20++)
			{
				AgentType tmp21;
				byte tmp23;
				tmp23 = s[offset];
				offset += Byte.BYTES;
				if (tmp23 == 1)
				{
					byte tmp24;
					tmp24 = s[offset];
					offset += Byte.BYTES;
					tmp21 = AgentType.of(tmp24);
				}
				else
					tmp21 = null;
				
				Agent tmp22;
				byte tmp25;
				tmp25 = s[offset];
				offset += Byte.BYTES;
				if (tmp25 == 1)
				{
					tmp22 = new Agent();
					offset = tmp22.deserialize(s, offset);
				}
				else
					tmp22 = null;
				
				agents.put(tmp21, tmp22);
			}
		}
		else
			agents = null;
		
		// deserialize frontlineDeliveries
		byte tmp26;
		tmp26 = s[offset];
		offset += Byte.BYTES;
		if (tmp26 == 1)
		{
			byte tmp27;
			tmp27 = s[offset];
			offset += Byte.BYTES;
			byte[] tmp28 = Arrays.copyOfRange(s, offset, offset + tmp27);
			offset += tmp27;
			int tmp29;
			tmp29 = ByteBuffer.wrap(Arrays.copyOfRange(tmp28, 0, 0 + Integer.BYTES)).order(ByteOrder.LITTLE_ENDIAN).getInt();
			
			frontlineDeliveries = new ArrayList<>();
			for (int tmp30 = 0; tmp30 < tmp29; tmp30++)
			{
				FrontlineDelivery tmp31;
				byte tmp32;
				tmp32 = s[offset];
				offset += Byte.BYTES;
				if (tmp32 == 1)
				{
					tmp31 = new FrontlineDelivery();
					offset = tmp31.deserialize(s, offset);
				}
				else
					tmp31 = null;
				frontlineDeliveries.add(tmp31);
			}
		}
		else
			frontlineDeliveries = null;
		
		// deserialize warehouse
		byte tmp33;
		tmp33 = s[offset];
		offset += Byte.BYTES;
		if (tmp33 == 1)
		{
			warehouse = new Warehouse();
			offset = warehouse.deserialize(s, offset);
		}
		else
			warehouse = null;
		
		// deserialize backlineDelivery
		byte tmp34;
		tmp34 = s[offset];
		offset += Byte.BYTES;
		if (tmp34 == 1)
		{
			backlineDelivery = new BacklineDelivery();
			offset = backlineDelivery.deserialize(s, offset);
		}
		else
			backlineDelivery = null;
		
		// deserialize factory
		byte tmp35;
		tmp35 = s[offset];
		offset += Byte.BYTES;
		if (tmp35 == 1)
		{
			factory = new Factory();
			offset = factory.deserialize(s, offset);
		}
		else
			factory = null;
		
		// deserialize units
		byte tmp36;
		tmp36 = s[offset];
		offset += Byte.BYTES;
		if (tmp36 == 1)
		{
			byte tmp37;
			tmp37 = s[offset];
			offset += Byte.BYTES;
			byte[] tmp38 = Arrays.copyOfRange(s, offset, offset + tmp37);
			offset += tmp37;
			int tmp39;
			tmp39 = ByteBuffer.wrap(Arrays.copyOfRange(tmp38, 0, 0 + Integer.BYTES)).order(ByteOrder.LITTLE_ENDIAN).getInt();
			
			units = new HashMap<>();
			for (int tmp40 = 0; tmp40 < tmp39; tmp40++)
			{
				UnitType tmp41;
				byte tmp43;
				tmp43 = s[offset];
				offset += Byte.BYTES;
				if (tmp43 == 1)
				{
					byte tmp44;
					tmp44 = s[offset];
					offset += Byte.BYTES;
					tmp41 = UnitType.of(tmp44);
				}
				else
					tmp41 = null;
				
				Unit tmp42;
				byte tmp45;
				tmp45 = s[offset];
				offset += Byte.BYTES;
				if (tmp45 == 1)
				{
					tmp42 = new Unit();
					offset = tmp42.deserialize(s, offset);
				}
				else
					tmp42 = null;
				
				units.put(tmp41, tmp42);
			}
		}
		else
			units = null;
		
		return offset;
	}
}
