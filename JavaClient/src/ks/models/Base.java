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
	protected FrontlineDelivery frontlineDelivery;
	protected Repository repository;
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
	
	public FrontlineDelivery getFrontlineDelivery()
	{
		return this.frontlineDelivery;
	}
	
	public Repository getRepository()
	{
		return this.repository;
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
	
	public void setFrontlineDelivery(FrontlineDelivery frontlineDelivery)
	{
		this.frontlineDelivery = frontlineDelivery;
	}
	
	public void setRepository(Repository repository)
	{
		this.repository = repository;
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
		
		// serialize frontlineDelivery
		s.add((byte) ((frontlineDelivery == null) ? 0 : 1));
		if (frontlineDelivery != null)
		{
			s.addAll(b2B(frontlineDelivery.serialize()));
		}
		
		// serialize repository
		s.add((byte) ((repository == null) ? 0 : 1));
		if (repository != null)
		{
			s.addAll(b2B(repository.serialize()));
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
			List<Byte> tmp4 = new ArrayList<>();
			tmp4.addAll(b2B(ByteBuffer.allocate(Integer.BYTES).order(ByteOrder.LITTLE_ENDIAN).putInt(units.size()).array()));
			while (tmp4.size() > 0 && tmp4.get(tmp4.size() - 1) == 0)
				tmp4.remove(tmp4.size() - 1);
			s.add((byte) tmp4.size());
			s.addAll(tmp4);
			
			for (Map.Entry<UnitType, Unit> tmp5 : units.entrySet())
			{
				s.add((byte) ((tmp5.getKey() == null) ? 0 : 1));
				if (tmp5.getKey() != null)
				{
					s.add((byte) (tmp5.getKey().getValue()));
				}
				
				s.add((byte) ((tmp5.getValue() == null) ? 0 : 1));
				if (tmp5.getValue() != null)
				{
					s.addAll(b2B(tmp5.getValue().serialize()));
				}
			}
		}
		
		return B2b(s);
	}
	
	@Override
	protected int deserialize(byte[] s, int offset)
	{
		// deserialize cArea
		byte tmp6;
		tmp6 = s[offset];
		offset += Byte.BYTES;
		if (tmp6 == 1)
		{
			byte tmp7;
			tmp7 = s[offset];
			offset += Byte.BYTES;
			byte[] tmp8 = Arrays.copyOfRange(s, offset, offset + tmp7);
			offset += tmp7;
			int tmp9;
			tmp9 = ByteBuffer.wrap(Arrays.copyOfRange(tmp8, 0, 0 + Integer.BYTES)).order(ByteOrder.LITTLE_ENDIAN).getInt();
			
			cArea = new ArrayList<>();
			for (int tmp10 = 0; tmp10 < tmp9; tmp10++)
			{
				ECell tmp11;
				byte tmp12;
				tmp12 = s[offset];
				offset += Byte.BYTES;
				if (tmp12 == 1)
				{
					byte tmp13;
					tmp13 = s[offset];
					offset += Byte.BYTES;
					tmp11 = ECell.of(tmp13);
				}
				else
					tmp11 = null;
				cArea.add(tmp11);
			}
		}
		else
			cArea = null;
		
		// deserialize agents
		byte tmp14;
		tmp14 = s[offset];
		offset += Byte.BYTES;
		if (tmp14 == 1)
		{
			byte tmp15;
			tmp15 = s[offset];
			offset += Byte.BYTES;
			byte[] tmp16 = Arrays.copyOfRange(s, offset, offset + tmp15);
			offset += tmp15;
			int tmp17;
			tmp17 = ByteBuffer.wrap(Arrays.copyOfRange(tmp16, 0, 0 + Integer.BYTES)).order(ByteOrder.LITTLE_ENDIAN).getInt();
			
			agents = new HashMap<>();
			for (int tmp18 = 0; tmp18 < tmp17; tmp18++)
			{
				AgentType tmp19;
				byte tmp21;
				tmp21 = s[offset];
				offset += Byte.BYTES;
				if (tmp21 == 1)
				{
					byte tmp22;
					tmp22 = s[offset];
					offset += Byte.BYTES;
					tmp19 = AgentType.of(tmp22);
				}
				else
					tmp19 = null;
				
				Agent tmp20;
				byte tmp23;
				tmp23 = s[offset];
				offset += Byte.BYTES;
				if (tmp23 == 1)
				{
					tmp20 = new Agent();
					offset = tmp20.deserialize(s, offset);
				}
				else
					tmp20 = null;
				
				agents.put(tmp19, tmp20);
			}
		}
		else
			agents = null;
		
		// deserialize frontlineDelivery
		byte tmp24;
		tmp24 = s[offset];
		offset += Byte.BYTES;
		if (tmp24 == 1)
		{
			frontlineDelivery = new FrontlineDelivery();
			offset = frontlineDelivery.deserialize(s, offset);
		}
		else
			frontlineDelivery = null;
		
		// deserialize repository
		byte tmp25;
		tmp25 = s[offset];
		offset += Byte.BYTES;
		if (tmp25 == 1)
		{
			repository = new Repository();
			offset = repository.deserialize(s, offset);
		}
		else
			repository = null;
		
		// deserialize backlineDelivery
		byte tmp26;
		tmp26 = s[offset];
		offset += Byte.BYTES;
		if (tmp26 == 1)
		{
			backlineDelivery = new BacklineDelivery();
			offset = backlineDelivery.deserialize(s, offset);
		}
		else
			backlineDelivery = null;
		
		// deserialize factory
		byte tmp27;
		tmp27 = s[offset];
		offset += Byte.BYTES;
		if (tmp27 == 1)
		{
			factory = new Factory();
			offset = factory.deserialize(s, offset);
		}
		else
			factory = null;
		
		// deserialize units
		byte tmp28;
		tmp28 = s[offset];
		offset += Byte.BYTES;
		if (tmp28 == 1)
		{
			byte tmp29;
			tmp29 = s[offset];
			offset += Byte.BYTES;
			byte[] tmp30 = Arrays.copyOfRange(s, offset, offset + tmp29);
			offset += tmp29;
			int tmp31;
			tmp31 = ByteBuffer.wrap(Arrays.copyOfRange(tmp30, 0, 0 + Integer.BYTES)).order(ByteOrder.LITTLE_ENDIAN).getInt();
			
			units = new HashMap<>();
			for (int tmp32 = 0; tmp32 < tmp31; tmp32++)
			{
				UnitType tmp33;
				byte tmp35;
				tmp35 = s[offset];
				offset += Byte.BYTES;
				if (tmp35 == 1)
				{
					byte tmp36;
					tmp36 = s[offset];
					offset += Byte.BYTES;
					tmp33 = UnitType.of(tmp36);
				}
				else
					tmp33 = null;
				
				Unit tmp34;
				byte tmp37;
				tmp37 = s[offset];
				offset += Byte.BYTES;
				if (tmp37 == 1)
				{
					tmp34 = new Unit();
					offset = tmp34.deserialize(s, offset);
				}
				else
					tmp34 = null;
				
				units.put(tmp33, tmp34);
			}
		}
		else
			units = null;
		
		return offset;
	}
}
