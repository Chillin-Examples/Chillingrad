package ks.models;

import java.lang.*;
import java.util.*;
import java.nio.*;
import java.nio.charset.Charset;

import ks.KSObject;

public class FrontlineDelivery extends KSObject
{
	protected Boolean isAvailable;
	protected Map<AmmoType, Integer> ammos;
	protected Integer truckDeliveryRemTime;
	protected Integer cTruckDeliveryDuration;
	protected Integer truckReturnRemTime;
	protected Integer cTruckReturnDuration;
	
	// getters
	
	public Boolean getIsAvailable()
	{
		return this.isAvailable;
	}
	
	public Map<AmmoType, Integer> getAmmos()
	{
		return this.ammos;
	}
	
	public Integer getTruckDeliveryRemTime()
	{
		return this.truckDeliveryRemTime;
	}
	
	public Integer getCTruckDeliveryDuration()
	{
		return this.cTruckDeliveryDuration;
	}
	
	public Integer getTruckReturnRemTime()
	{
		return this.truckReturnRemTime;
	}
	
	public Integer getCTruckReturnDuration()
	{
		return this.cTruckReturnDuration;
	}
	
	
	// setters
	
	public void setIsAvailable(Boolean isAvailable)
	{
		this.isAvailable = isAvailable;
	}
	
	public void setAmmos(Map<AmmoType, Integer> ammos)
	{
		this.ammos = ammos;
	}
	
	public void setTruckDeliveryRemTime(Integer truckDeliveryRemTime)
	{
		this.truckDeliveryRemTime = truckDeliveryRemTime;
	}
	
	public void setCTruckDeliveryDuration(Integer cTruckDeliveryDuration)
	{
		this.cTruckDeliveryDuration = cTruckDeliveryDuration;
	}
	
	public void setTruckReturnRemTime(Integer truckReturnRemTime)
	{
		this.truckReturnRemTime = truckReturnRemTime;
	}
	
	public void setCTruckReturnDuration(Integer cTruckReturnDuration)
	{
		this.cTruckReturnDuration = cTruckReturnDuration;
	}
	
	
	public FrontlineDelivery()
	{
	}
	
	public static final String nameStatic = "FrontlineDelivery";
	
	@Override
	public String name() { return "FrontlineDelivery"; }
	
	@Override
	public byte[] serialize()
	{
		List<Byte> s = new ArrayList<>();
		
		// serialize isAvailable
		s.add((byte) ((isAvailable == null) ? 0 : 1));
		if (isAvailable != null)
		{
			s.add((byte) ((isAvailable) ? 1 : 0));
		}
		
		// serialize ammos
		s.add((byte) ((ammos == null) ? 0 : 1));
		if (ammos != null)
		{
			List<Byte> tmp0 = new ArrayList<>();
			tmp0.addAll(b2B(ByteBuffer.allocate(Integer.BYTES).order(ByteOrder.LITTLE_ENDIAN).putInt(ammos.size()).array()));
			while (tmp0.size() > 0 && tmp0.get(tmp0.size() - 1) == 0)
				tmp0.remove(tmp0.size() - 1);
			s.add((byte) tmp0.size());
			s.addAll(tmp0);
			
			for (Map.Entry<AmmoType, Integer> tmp1 : ammos.entrySet())
			{
				s.add((byte) ((tmp1.getKey() == null) ? 0 : 1));
				if (tmp1.getKey() != null)
				{
					s.add((byte) (tmp1.getKey().getValue()));
				}
				
				s.add((byte) ((tmp1.getValue() == null) ? 0 : 1));
				if (tmp1.getValue() != null)
				{
					s.addAll(b2B(ByteBuffer.allocate(Integer.BYTES).order(ByteOrder.LITTLE_ENDIAN).putInt(tmp1.getValue()).array()));
				}
			}
		}
		
		// serialize truckDeliveryRemTime
		s.add((byte) ((truckDeliveryRemTime == null) ? 0 : 1));
		if (truckDeliveryRemTime != null)
		{
			s.addAll(b2B(ByteBuffer.allocate(Integer.BYTES).order(ByteOrder.LITTLE_ENDIAN).putInt(truckDeliveryRemTime).array()));
		}
		
		// serialize cTruckDeliveryDuration
		s.add((byte) ((cTruckDeliveryDuration == null) ? 0 : 1));
		if (cTruckDeliveryDuration != null)
		{
			s.addAll(b2B(ByteBuffer.allocate(Integer.BYTES).order(ByteOrder.LITTLE_ENDIAN).putInt(cTruckDeliveryDuration).array()));
		}
		
		// serialize truckReturnRemTime
		s.add((byte) ((truckReturnRemTime == null) ? 0 : 1));
		if (truckReturnRemTime != null)
		{
			s.addAll(b2B(ByteBuffer.allocate(Integer.BYTES).order(ByteOrder.LITTLE_ENDIAN).putInt(truckReturnRemTime).array()));
		}
		
		// serialize cTruckReturnDuration
		s.add((byte) ((cTruckReturnDuration == null) ? 0 : 1));
		if (cTruckReturnDuration != null)
		{
			s.addAll(b2B(ByteBuffer.allocate(Integer.BYTES).order(ByteOrder.LITTLE_ENDIAN).putInt(cTruckReturnDuration).array()));
		}
		
		return B2b(s);
	}
	
	@Override
	protected int deserialize(byte[] s, int offset)
	{
		// deserialize isAvailable
		byte tmp2;
		tmp2 = s[offset];
		offset += Byte.BYTES;
		if (tmp2 == 1)
		{
			isAvailable = (s[offset] == 0) ? false : true;
			offset += Byte.BYTES;
		}
		else
			isAvailable = null;
		
		// deserialize ammos
		byte tmp3;
		tmp3 = s[offset];
		offset += Byte.BYTES;
		if (tmp3 == 1)
		{
			byte tmp4;
			tmp4 = s[offset];
			offset += Byte.BYTES;
			byte[] tmp5 = Arrays.copyOfRange(s, offset, offset + tmp4);
			offset += tmp4;
			int tmp6;
			tmp6 = ByteBuffer.wrap(Arrays.copyOfRange(tmp5, 0, 0 + Integer.BYTES)).order(ByteOrder.LITTLE_ENDIAN).getInt();
			
			ammos = new HashMap<>();
			for (int tmp7 = 0; tmp7 < tmp6; tmp7++)
			{
				AmmoType tmp8;
				byte tmp10;
				tmp10 = s[offset];
				offset += Byte.BYTES;
				if (tmp10 == 1)
				{
					byte tmp11;
					tmp11 = s[offset];
					offset += Byte.BYTES;
					tmp8 = AmmoType.of(tmp11);
				}
				else
					tmp8 = null;
				
				Integer tmp9;
				byte tmp12;
				tmp12 = s[offset];
				offset += Byte.BYTES;
				if (tmp12 == 1)
				{
					tmp9 = ByteBuffer.wrap(Arrays.copyOfRange(s, offset, offset + Integer.BYTES)).order(ByteOrder.LITTLE_ENDIAN).getInt();
					offset += Integer.BYTES;
				}
				else
					tmp9 = null;
				
				ammos.put(tmp8, tmp9);
			}
		}
		else
			ammos = null;
		
		// deserialize truckDeliveryRemTime
		byte tmp13;
		tmp13 = s[offset];
		offset += Byte.BYTES;
		if (tmp13 == 1)
		{
			truckDeliveryRemTime = ByteBuffer.wrap(Arrays.copyOfRange(s, offset, offset + Integer.BYTES)).order(ByteOrder.LITTLE_ENDIAN).getInt();
			offset += Integer.BYTES;
		}
		else
			truckDeliveryRemTime = null;
		
		// deserialize cTruckDeliveryDuration
		byte tmp14;
		tmp14 = s[offset];
		offset += Byte.BYTES;
		if (tmp14 == 1)
		{
			cTruckDeliveryDuration = ByteBuffer.wrap(Arrays.copyOfRange(s, offset, offset + Integer.BYTES)).order(ByteOrder.LITTLE_ENDIAN).getInt();
			offset += Integer.BYTES;
		}
		else
			cTruckDeliveryDuration = null;
		
		// deserialize truckReturnRemTime
		byte tmp15;
		tmp15 = s[offset];
		offset += Byte.BYTES;
		if (tmp15 == 1)
		{
			truckReturnRemTime = ByteBuffer.wrap(Arrays.copyOfRange(s, offset, offset + Integer.BYTES)).order(ByteOrder.LITTLE_ENDIAN).getInt();
			offset += Integer.BYTES;
		}
		else
			truckReturnRemTime = null;
		
		// deserialize cTruckReturnDuration
		byte tmp16;
		tmp16 = s[offset];
		offset += Byte.BYTES;
		if (tmp16 == 1)
		{
			cTruckReturnDuration = ByteBuffer.wrap(Arrays.copyOfRange(s, offset, offset + Integer.BYTES)).order(ByteOrder.LITTLE_ENDIAN).getInt();
			offset += Integer.BYTES;
		}
		else
			cTruckReturnDuration = null;
		
		return offset;
	}
}
