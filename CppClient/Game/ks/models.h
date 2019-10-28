#ifndef _KS_MODELS_H_
#define _KS_MODELS_H_

#include <string>
#include <vector>
#include <map>
#include <array>


namespace ks
{

#ifndef _KS_OBJECT_
#define _KS_OBJECT_

class KSObject
{
public:
	static inline const std::string nameStatic() { return ""; }
	virtual inline const std::string name() const = 0;
	virtual std::string serialize() const = 0;
	virtual unsigned int deserialize(const std::string &, unsigned int = 0) = 0;
};

#endif // _KS_OBJECT_


namespace models
{

enum class ECell
{
	Empty = 0,
	FrontlineDelivery = 1,
	Material = 2,
	BacklineDelivery = 3,
	Machine = 4,
};


enum class MachineStatus
{
	Idle = 0,
	Working = 1,
	AmmoReady = 2,
};


enum class MaterialType
{
	Powder = 0,
	Steel = 1,
	Aluminum = 2,
	Shell = 3,
	Nickel = 4,
	Manganese = 5,
	Chromium = 6,
};


enum class AmmoType
{
	RifleBullet = 0,
	TankShell = 1,
	Bomb = 2,
	ArtilleryShell = 3,
	HMGBullet = 4,
};


enum class UnitType
{
	Soldier = 0,
	Tank = 1,
	Aircraft = 2,
	Artillery = 3,
	HeavyMachineGunner = 4,
};


enum class AgentType
{
	Repository = 0,
	Factory = 1,
};


class Position : public KSObject
{

protected:

	int __index;

	bool __has_index;


public: // getters

	inline int index() const
	{
		return __index;
	}
	

public: // reference getters

	inline int &ref_index() const
	{
		return (int&) __index;
	}
	

public: // setters

	inline void index(const int &index)
	{
		__index = index;
		has_index(true);
	}
	

public: // has_attribute getters

	inline bool has_index() const
	{
		return __has_index;
	}
	

public: // has_attribute setters

	inline void has_index(const bool &has_index)
	{
		__has_index = has_index;
	}
	

public:

	Position()
	{
		has_index(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "Position";
	}
	
	virtual inline const std::string name() const
	{
		return "Position";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize index
		s += __has_index;
		if (__has_index)
		{
			int tmp1 = __index;
			auto tmp2 = reinterpret_cast<char*>(&tmp1);
			s += std::string(tmp2, sizeof(int));
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize index
		__has_index = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_index)
		{
			__index = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		return offset;
	}
};


class Material : public KSObject
{

protected:

	MaterialType __type;
	Position __position;
	int __count;
	int __cCapacity;

	bool __has_type;
	bool __has_position;
	bool __has_count;
	bool __has_cCapacity;


public: // getters

	inline MaterialType type() const
	{
		return __type;
	}
	
	inline Position position() const
	{
		return __position;
	}
	
	inline int count() const
	{
		return __count;
	}
	
	inline int cCapacity() const
	{
		return __cCapacity;
	}
	

public: // reference getters

	inline MaterialType &ref_type() const
	{
		return (MaterialType&) __type;
	}
	
	inline Position &ref_position() const
	{
		return (Position&) __position;
	}
	
	inline int &ref_count() const
	{
		return (int&) __count;
	}
	
	inline int &ref_cCapacity() const
	{
		return (int&) __cCapacity;
	}
	

public: // setters

	inline void type(const MaterialType &type)
	{
		__type = type;
		has_type(true);
	}
	
	inline void position(const Position &position)
	{
		__position = position;
		has_position(true);
	}
	
	inline void count(const int &count)
	{
		__count = count;
		has_count(true);
	}
	
	inline void cCapacity(const int &cCapacity)
	{
		__cCapacity = cCapacity;
		has_cCapacity(true);
	}
	

public: // has_attribute getters

	inline bool has_type() const
	{
		return __has_type;
	}
	
	inline bool has_position() const
	{
		return __has_position;
	}
	
	inline bool has_count() const
	{
		return __has_count;
	}
	
	inline bool has_cCapacity() const
	{
		return __has_cCapacity;
	}
	

public: // has_attribute setters

	inline void has_type(const bool &has_type)
	{
		__has_type = has_type;
	}
	
	inline void has_position(const bool &has_position)
	{
		__has_position = has_position;
	}
	
	inline void has_count(const bool &has_count)
	{
		__has_count = has_count;
	}
	
	inline void has_cCapacity(const bool &has_cCapacity)
	{
		__has_cCapacity = has_cCapacity;
	}
	

public:

	Material()
	{
		has_type(false);
		has_position(false);
		has_count(false);
		has_cCapacity(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "Material";
	}
	
	virtual inline const std::string name() const
	{
		return "Material";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize type
		s += __has_type;
		if (__has_type)
		{
			char tmp4 = (char) __type;
			auto tmp5 = reinterpret_cast<char*>(&tmp4);
			s += std::string(tmp5, sizeof(char));
		}
		
		// serialize position
		s += __has_position;
		if (__has_position)
		{
			s += __position.serialize();
		}
		
		// serialize count
		s += __has_count;
		if (__has_count)
		{
			int tmp7 = __count;
			auto tmp8 = reinterpret_cast<char*>(&tmp7);
			s += std::string(tmp8, sizeof(int));
		}
		
		// serialize cCapacity
		s += __has_cCapacity;
		if (__has_cCapacity)
		{
			int tmp10 = __cCapacity;
			auto tmp11 = reinterpret_cast<char*>(&tmp10);
			s += std::string(tmp11, sizeof(int));
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize type
		__has_type = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_type)
		{
			char tmp12;
			tmp12 = *((char*) (&s[offset]));
			offset += sizeof(char);
			__type = (MaterialType) tmp12;
		}
		
		// deserialize position
		__has_position = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_position)
		{
			offset = __position.deserialize(s, offset);
		}
		
		// deserialize count
		__has_count = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_count)
		{
			__count = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		// deserialize cCapacity
		__has_cCapacity = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cCapacity)
		{
			__cCapacity = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		return offset;
	}
};


class Machine : public KSObject
{

protected:

	MachineStatus __status;
	Position __position;
	AmmoType __currentAmmo;
	int __constructionRemTime;

	bool __has_status;
	bool __has_position;
	bool __has_currentAmmo;
	bool __has_constructionRemTime;


public: // getters

	inline MachineStatus status() const
	{
		return __status;
	}
	
	inline Position position() const
	{
		return __position;
	}
	
	inline AmmoType currentAmmo() const
	{
		return __currentAmmo;
	}
	
	inline int constructionRemTime() const
	{
		return __constructionRemTime;
	}
	

public: // reference getters

	inline MachineStatus &ref_status() const
	{
		return (MachineStatus&) __status;
	}
	
	inline Position &ref_position() const
	{
		return (Position&) __position;
	}
	
	inline AmmoType &ref_currentAmmo() const
	{
		return (AmmoType&) __currentAmmo;
	}
	
	inline int &ref_constructionRemTime() const
	{
		return (int&) __constructionRemTime;
	}
	

public: // setters

	inline void status(const MachineStatus &status)
	{
		__status = status;
		has_status(true);
	}
	
	inline void position(const Position &position)
	{
		__position = position;
		has_position(true);
	}
	
	inline void currentAmmo(const AmmoType &currentAmmo)
	{
		__currentAmmo = currentAmmo;
		has_currentAmmo(true);
	}
	
	inline void constructionRemTime(const int &constructionRemTime)
	{
		__constructionRemTime = constructionRemTime;
		has_constructionRemTime(true);
	}
	

public: // has_attribute getters

	inline bool has_status() const
	{
		return __has_status;
	}
	
	inline bool has_position() const
	{
		return __has_position;
	}
	
	inline bool has_currentAmmo() const
	{
		return __has_currentAmmo;
	}
	
	inline bool has_constructionRemTime() const
	{
		return __has_constructionRemTime;
	}
	

public: // has_attribute setters

	inline void has_status(const bool &has_status)
	{
		__has_status = has_status;
	}
	
	inline void has_position(const bool &has_position)
	{
		__has_position = has_position;
	}
	
	inline void has_currentAmmo(const bool &has_currentAmmo)
	{
		__has_currentAmmo = has_currentAmmo;
	}
	
	inline void has_constructionRemTime(const bool &has_constructionRemTime)
	{
		__has_constructionRemTime = has_constructionRemTime;
	}
	

public:

	Machine()
	{
		has_status(false);
		has_position(false);
		has_currentAmmo(false);
		has_constructionRemTime(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "Machine";
	}
	
	virtual inline const std::string name() const
	{
		return "Machine";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize status
		s += __has_status;
		if (__has_status)
		{
			char tmp14 = (char) __status;
			auto tmp15 = reinterpret_cast<char*>(&tmp14);
			s += std::string(tmp15, sizeof(char));
		}
		
		// serialize position
		s += __has_position;
		if (__has_position)
		{
			s += __position.serialize();
		}
		
		// serialize currentAmmo
		s += __has_currentAmmo;
		if (__has_currentAmmo)
		{
			char tmp17 = (char) __currentAmmo;
			auto tmp18 = reinterpret_cast<char*>(&tmp17);
			s += std::string(tmp18, sizeof(char));
		}
		
		// serialize constructionRemTime
		s += __has_constructionRemTime;
		if (__has_constructionRemTime)
		{
			int tmp20 = __constructionRemTime;
			auto tmp21 = reinterpret_cast<char*>(&tmp20);
			s += std::string(tmp21, sizeof(int));
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize status
		__has_status = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_status)
		{
			char tmp22;
			tmp22 = *((char*) (&s[offset]));
			offset += sizeof(char);
			__status = (MachineStatus) tmp22;
		}
		
		// deserialize position
		__has_position = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_position)
		{
			offset = __position.deserialize(s, offset);
		}
		
		// deserialize currentAmmo
		__has_currentAmmo = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_currentAmmo)
		{
			char tmp23;
			tmp23 = *((char*) (&s[offset]));
			offset += sizeof(char);
			__currentAmmo = (AmmoType) tmp23;
		}
		
		// deserialize constructionRemTime
		__has_constructionRemTime = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_constructionRemTime)
		{
			__constructionRemTime = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		return offset;
	}
};


class FrontlineDelivery : public KSObject
{

protected:

	bool __isAvailable;
	std::map<AmmoType, int> __ammos;
	int __truckDeliveryRemTime;
	int __cTruckDeliveryDuration;
	int __truckReturnRemTime;
	int __cTruckReturnDuration;

	bool __has_isAvailable;
	bool __has_ammos;
	bool __has_truckDeliveryRemTime;
	bool __has_cTruckDeliveryDuration;
	bool __has_truckReturnRemTime;
	bool __has_cTruckReturnDuration;


public: // getters

	inline bool isAvailable() const
	{
		return __isAvailable;
	}
	
	inline std::map<AmmoType, int> ammos() const
	{
		return __ammos;
	}
	
	inline int truckDeliveryRemTime() const
	{
		return __truckDeliveryRemTime;
	}
	
	inline int cTruckDeliveryDuration() const
	{
		return __cTruckDeliveryDuration;
	}
	
	inline int truckReturnRemTime() const
	{
		return __truckReturnRemTime;
	}
	
	inline int cTruckReturnDuration() const
	{
		return __cTruckReturnDuration;
	}
	

public: // reference getters

	inline bool &ref_isAvailable() const
	{
		return (bool&) __isAvailable;
	}
	
	inline std::map<AmmoType, int> &ref_ammos() const
	{
		return (std::map<AmmoType, int>&) __ammos;
	}
	
	inline int &ref_truckDeliveryRemTime() const
	{
		return (int&) __truckDeliveryRemTime;
	}
	
	inline int &ref_cTruckDeliveryDuration() const
	{
		return (int&) __cTruckDeliveryDuration;
	}
	
	inline int &ref_truckReturnRemTime() const
	{
		return (int&) __truckReturnRemTime;
	}
	
	inline int &ref_cTruckReturnDuration() const
	{
		return (int&) __cTruckReturnDuration;
	}
	

public: // setters

	inline void isAvailable(const bool &isAvailable)
	{
		__isAvailable = isAvailable;
		has_isAvailable(true);
	}
	
	inline void ammos(const std::map<AmmoType, int> &ammos)
	{
		__ammos = ammos;
		has_ammos(true);
	}
	
	inline void truckDeliveryRemTime(const int &truckDeliveryRemTime)
	{
		__truckDeliveryRemTime = truckDeliveryRemTime;
		has_truckDeliveryRemTime(true);
	}
	
	inline void cTruckDeliveryDuration(const int &cTruckDeliveryDuration)
	{
		__cTruckDeliveryDuration = cTruckDeliveryDuration;
		has_cTruckDeliveryDuration(true);
	}
	
	inline void truckReturnRemTime(const int &truckReturnRemTime)
	{
		__truckReturnRemTime = truckReturnRemTime;
		has_truckReturnRemTime(true);
	}
	
	inline void cTruckReturnDuration(const int &cTruckReturnDuration)
	{
		__cTruckReturnDuration = cTruckReturnDuration;
		has_cTruckReturnDuration(true);
	}
	

public: // has_attribute getters

	inline bool has_isAvailable() const
	{
		return __has_isAvailable;
	}
	
	inline bool has_ammos() const
	{
		return __has_ammos;
	}
	
	inline bool has_truckDeliveryRemTime() const
	{
		return __has_truckDeliveryRemTime;
	}
	
	inline bool has_cTruckDeliveryDuration() const
	{
		return __has_cTruckDeliveryDuration;
	}
	
	inline bool has_truckReturnRemTime() const
	{
		return __has_truckReturnRemTime;
	}
	
	inline bool has_cTruckReturnDuration() const
	{
		return __has_cTruckReturnDuration;
	}
	

public: // has_attribute setters

	inline void has_isAvailable(const bool &has_isAvailable)
	{
		__has_isAvailable = has_isAvailable;
	}
	
	inline void has_ammos(const bool &has_ammos)
	{
		__has_ammos = has_ammos;
	}
	
	inline void has_truckDeliveryRemTime(const bool &has_truckDeliveryRemTime)
	{
		__has_truckDeliveryRemTime = has_truckDeliveryRemTime;
	}
	
	inline void has_cTruckDeliveryDuration(const bool &has_cTruckDeliveryDuration)
	{
		__has_cTruckDeliveryDuration = has_cTruckDeliveryDuration;
	}
	
	inline void has_truckReturnRemTime(const bool &has_truckReturnRemTime)
	{
		__has_truckReturnRemTime = has_truckReturnRemTime;
	}
	
	inline void has_cTruckReturnDuration(const bool &has_cTruckReturnDuration)
	{
		__has_cTruckReturnDuration = has_cTruckReturnDuration;
	}
	

public:

	FrontlineDelivery()
	{
		has_isAvailable(false);
		has_ammos(false);
		has_truckDeliveryRemTime(false);
		has_cTruckDeliveryDuration(false);
		has_truckReturnRemTime(false);
		has_cTruckReturnDuration(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "FrontlineDelivery";
	}
	
	virtual inline const std::string name() const
	{
		return "FrontlineDelivery";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize isAvailable
		s += __has_isAvailable;
		if (__has_isAvailable)
		{
			bool tmp25 = __isAvailable;
			auto tmp26 = reinterpret_cast<char*>(&tmp25);
			s += std::string(tmp26, sizeof(bool));
		}
		
		// serialize ammos
		s += __has_ammos;
		if (__has_ammos)
		{
			std::string tmp27 = "";
			unsigned int tmp29 = __ammos.size();
			auto tmp30 = reinterpret_cast<char*>(&tmp29);
			tmp27 += std::string(tmp30, sizeof(unsigned int));
			while (tmp27.size() && tmp27.back() == 0)
				tmp27.pop_back();
			unsigned char tmp32 = tmp27.size();
			auto tmp33 = reinterpret_cast<char*>(&tmp32);
			s += std::string(tmp33, sizeof(unsigned char));
			s += tmp27;
			
			for (auto &tmp34 : __ammos)
			{
				s += '\x01';
				char tmp36 = (char) tmp34.first;
				auto tmp37 = reinterpret_cast<char*>(&tmp36);
				s += std::string(tmp37, sizeof(char));
				
				s += '\x01';
				int tmp39 = tmp34.second;
				auto tmp40 = reinterpret_cast<char*>(&tmp39);
				s += std::string(tmp40, sizeof(int));
			}
		}
		
		// serialize truckDeliveryRemTime
		s += __has_truckDeliveryRemTime;
		if (__has_truckDeliveryRemTime)
		{
			int tmp42 = __truckDeliveryRemTime;
			auto tmp43 = reinterpret_cast<char*>(&tmp42);
			s += std::string(tmp43, sizeof(int));
		}
		
		// serialize cTruckDeliveryDuration
		s += __has_cTruckDeliveryDuration;
		if (__has_cTruckDeliveryDuration)
		{
			int tmp45 = __cTruckDeliveryDuration;
			auto tmp46 = reinterpret_cast<char*>(&tmp45);
			s += std::string(tmp46, sizeof(int));
		}
		
		// serialize truckReturnRemTime
		s += __has_truckReturnRemTime;
		if (__has_truckReturnRemTime)
		{
			int tmp48 = __truckReturnRemTime;
			auto tmp49 = reinterpret_cast<char*>(&tmp48);
			s += std::string(tmp49, sizeof(int));
		}
		
		// serialize cTruckReturnDuration
		s += __has_cTruckReturnDuration;
		if (__has_cTruckReturnDuration)
		{
			int tmp51 = __cTruckReturnDuration;
			auto tmp52 = reinterpret_cast<char*>(&tmp51);
			s += std::string(tmp52, sizeof(int));
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize isAvailable
		__has_isAvailable = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_isAvailable)
		{
			__isAvailable = *((bool*) (&s[offset]));
			offset += sizeof(bool);
		}
		
		// deserialize ammos
		__has_ammos = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_ammos)
		{
			unsigned char tmp53;
			tmp53 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp54 = std::string(&s[offset], tmp53);
			offset += tmp53;
			while (tmp54.size() < sizeof(unsigned int))
				tmp54 += '\x00';
			unsigned int tmp55;
			tmp55 = *((unsigned int*) (&tmp54[0]));
			
			__ammos.clear();
			for (unsigned int tmp56 = 0; tmp56 < tmp55; tmp56++)
			{
				AmmoType tmp57;
				offset++;
				char tmp59;
				tmp59 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp57 = (AmmoType) tmp59;
				
				int tmp58;
				offset++;
				tmp58 = *((int*) (&s[offset]));
				offset += sizeof(int);
				
				__ammos[tmp57] = tmp58;
			}
		}
		
		// deserialize truckDeliveryRemTime
		__has_truckDeliveryRemTime = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_truckDeliveryRemTime)
		{
			__truckDeliveryRemTime = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		// deserialize cTruckDeliveryDuration
		__has_cTruckDeliveryDuration = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cTruckDeliveryDuration)
		{
			__cTruckDeliveryDuration = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		// deserialize truckReturnRemTime
		__has_truckReturnRemTime = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_truckReturnRemTime)
		{
			__truckReturnRemTime = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		// deserialize cTruckReturnDuration
		__has_cTruckReturnDuration = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cTruckReturnDuration)
		{
			__cTruckReturnDuration = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		return offset;
	}
};


class Repository : public KSObject
{

protected:

	std::map<Position, Material> __materials;
	int __materialsReloadRemTime;
	int __cMaterialsReloadDuration;

	bool __has_materials;
	bool __has_materialsReloadRemTime;
	bool __has_cMaterialsReloadDuration;


public: // getters

	inline std::map<Position, Material> materials() const
	{
		return __materials;
	}
	
	inline int materialsReloadRemTime() const
	{
		return __materialsReloadRemTime;
	}
	
	inline int cMaterialsReloadDuration() const
	{
		return __cMaterialsReloadDuration;
	}
	

public: // reference getters

	inline std::map<Position, Material> &ref_materials() const
	{
		return (std::map<Position, Material>&) __materials;
	}
	
	inline int &ref_materialsReloadRemTime() const
	{
		return (int&) __materialsReloadRemTime;
	}
	
	inline int &ref_cMaterialsReloadDuration() const
	{
		return (int&) __cMaterialsReloadDuration;
	}
	

public: // setters

	inline void materials(const std::map<Position, Material> &materials)
	{
		__materials = materials;
		has_materials(true);
	}
	
	inline void materialsReloadRemTime(const int &materialsReloadRemTime)
	{
		__materialsReloadRemTime = materialsReloadRemTime;
		has_materialsReloadRemTime(true);
	}
	
	inline void cMaterialsReloadDuration(const int &cMaterialsReloadDuration)
	{
		__cMaterialsReloadDuration = cMaterialsReloadDuration;
		has_cMaterialsReloadDuration(true);
	}
	

public: // has_attribute getters

	inline bool has_materials() const
	{
		return __has_materials;
	}
	
	inline bool has_materialsReloadRemTime() const
	{
		return __has_materialsReloadRemTime;
	}
	
	inline bool has_cMaterialsReloadDuration() const
	{
		return __has_cMaterialsReloadDuration;
	}
	

public: // has_attribute setters

	inline void has_materials(const bool &has_materials)
	{
		__has_materials = has_materials;
	}
	
	inline void has_materialsReloadRemTime(const bool &has_materialsReloadRemTime)
	{
		__has_materialsReloadRemTime = has_materialsReloadRemTime;
	}
	
	inline void has_cMaterialsReloadDuration(const bool &has_cMaterialsReloadDuration)
	{
		__has_cMaterialsReloadDuration = has_cMaterialsReloadDuration;
	}
	

public:

	Repository()
	{
		has_materials(false);
		has_materialsReloadRemTime(false);
		has_cMaterialsReloadDuration(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "Repository";
	}
	
	virtual inline const std::string name() const
	{
		return "Repository";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize materials
		s += __has_materials;
		if (__has_materials)
		{
			std::string tmp60 = "";
			unsigned int tmp62 = __materials.size();
			auto tmp63 = reinterpret_cast<char*>(&tmp62);
			tmp60 += std::string(tmp63, sizeof(unsigned int));
			while (tmp60.size() && tmp60.back() == 0)
				tmp60.pop_back();
			unsigned char tmp65 = tmp60.size();
			auto tmp66 = reinterpret_cast<char*>(&tmp65);
			s += std::string(tmp66, sizeof(unsigned char));
			s += tmp60;
			
			for (auto &tmp67 : __materials)
			{
				s += '\x01';
				s += tmp67.first.serialize();
				
				s += '\x01';
				s += tmp67.second.serialize();
			}
		}
		
		// serialize materialsReloadRemTime
		s += __has_materialsReloadRemTime;
		if (__has_materialsReloadRemTime)
		{
			int tmp69 = __materialsReloadRemTime;
			auto tmp70 = reinterpret_cast<char*>(&tmp69);
			s += std::string(tmp70, sizeof(int));
		}
		
		// serialize cMaterialsReloadDuration
		s += __has_cMaterialsReloadDuration;
		if (__has_cMaterialsReloadDuration)
		{
			int tmp72 = __cMaterialsReloadDuration;
			auto tmp73 = reinterpret_cast<char*>(&tmp72);
			s += std::string(tmp73, sizeof(int));
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize materials
		__has_materials = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_materials)
		{
			unsigned char tmp74;
			tmp74 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp75 = std::string(&s[offset], tmp74);
			offset += tmp74;
			while (tmp75.size() < sizeof(unsigned int))
				tmp75 += '\x00';
			unsigned int tmp76;
			tmp76 = *((unsigned int*) (&tmp75[0]));
			
			__materials.clear();
			for (unsigned int tmp77 = 0; tmp77 < tmp76; tmp77++)
			{
				Position tmp78;
				offset++;
				offset = tmp78.deserialize(s, offset);
				
				Material tmp79;
				offset++;
				offset = tmp79.deserialize(s, offset);
				
				__materials[tmp78] = tmp79;
			}
		}
		
		// deserialize materialsReloadRemTime
		__has_materialsReloadRemTime = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_materialsReloadRemTime)
		{
			__materialsReloadRemTime = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		// deserialize cMaterialsReloadDuration
		__has_cMaterialsReloadDuration = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cMaterialsReloadDuration)
		{
			__cMaterialsReloadDuration = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		return offset;
	}
};


class BacklineDelivery : public KSObject
{

protected:

	std::map<MaterialType, int> __materials;
	std::map<AmmoType, int> __ammos;

	bool __has_materials;
	bool __has_ammos;


public: // getters

	inline std::map<MaterialType, int> materials() const
	{
		return __materials;
	}
	
	inline std::map<AmmoType, int> ammos() const
	{
		return __ammos;
	}
	

public: // reference getters

	inline std::map<MaterialType, int> &ref_materials() const
	{
		return (std::map<MaterialType, int>&) __materials;
	}
	
	inline std::map<AmmoType, int> &ref_ammos() const
	{
		return (std::map<AmmoType, int>&) __ammos;
	}
	

public: // setters

	inline void materials(const std::map<MaterialType, int> &materials)
	{
		__materials = materials;
		has_materials(true);
	}
	
	inline void ammos(const std::map<AmmoType, int> &ammos)
	{
		__ammos = ammos;
		has_ammos(true);
	}
	

public: // has_attribute getters

	inline bool has_materials() const
	{
		return __has_materials;
	}
	
	inline bool has_ammos() const
	{
		return __has_ammos;
	}
	

public: // has_attribute setters

	inline void has_materials(const bool &has_materials)
	{
		__has_materials = has_materials;
	}
	
	inline void has_ammos(const bool &has_ammos)
	{
		__has_ammos = has_ammos;
	}
	

public:

	BacklineDelivery()
	{
		has_materials(false);
		has_ammos(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "BacklineDelivery";
	}
	
	virtual inline const std::string name() const
	{
		return "BacklineDelivery";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize materials
		s += __has_materials;
		if (__has_materials)
		{
			std::string tmp80 = "";
			unsigned int tmp82 = __materials.size();
			auto tmp83 = reinterpret_cast<char*>(&tmp82);
			tmp80 += std::string(tmp83, sizeof(unsigned int));
			while (tmp80.size() && tmp80.back() == 0)
				tmp80.pop_back();
			unsigned char tmp85 = tmp80.size();
			auto tmp86 = reinterpret_cast<char*>(&tmp85);
			s += std::string(tmp86, sizeof(unsigned char));
			s += tmp80;
			
			for (auto &tmp87 : __materials)
			{
				s += '\x01';
				char tmp89 = (char) tmp87.first;
				auto tmp90 = reinterpret_cast<char*>(&tmp89);
				s += std::string(tmp90, sizeof(char));
				
				s += '\x01';
				int tmp92 = tmp87.second;
				auto tmp93 = reinterpret_cast<char*>(&tmp92);
				s += std::string(tmp93, sizeof(int));
			}
		}
		
		// serialize ammos
		s += __has_ammos;
		if (__has_ammos)
		{
			std::string tmp94 = "";
			unsigned int tmp96 = __ammos.size();
			auto tmp97 = reinterpret_cast<char*>(&tmp96);
			tmp94 += std::string(tmp97, sizeof(unsigned int));
			while (tmp94.size() && tmp94.back() == 0)
				tmp94.pop_back();
			unsigned char tmp99 = tmp94.size();
			auto tmp100 = reinterpret_cast<char*>(&tmp99);
			s += std::string(tmp100, sizeof(unsigned char));
			s += tmp94;
			
			for (auto &tmp101 : __ammos)
			{
				s += '\x01';
				char tmp103 = (char) tmp101.first;
				auto tmp104 = reinterpret_cast<char*>(&tmp103);
				s += std::string(tmp104, sizeof(char));
				
				s += '\x01';
				int tmp106 = tmp101.second;
				auto tmp107 = reinterpret_cast<char*>(&tmp106);
				s += std::string(tmp107, sizeof(int));
			}
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize materials
		__has_materials = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_materials)
		{
			unsigned char tmp108;
			tmp108 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp109 = std::string(&s[offset], tmp108);
			offset += tmp108;
			while (tmp109.size() < sizeof(unsigned int))
				tmp109 += '\x00';
			unsigned int tmp110;
			tmp110 = *((unsigned int*) (&tmp109[0]));
			
			__materials.clear();
			for (unsigned int tmp111 = 0; tmp111 < tmp110; tmp111++)
			{
				MaterialType tmp112;
				offset++;
				char tmp114;
				tmp114 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp112 = (MaterialType) tmp114;
				
				int tmp113;
				offset++;
				tmp113 = *((int*) (&s[offset]));
				offset += sizeof(int);
				
				__materials[tmp112] = tmp113;
			}
		}
		
		// deserialize ammos
		__has_ammos = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_ammos)
		{
			unsigned char tmp115;
			tmp115 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp116 = std::string(&s[offset], tmp115);
			offset += tmp115;
			while (tmp116.size() < sizeof(unsigned int))
				tmp116 += '\x00';
			unsigned int tmp117;
			tmp117 = *((unsigned int*) (&tmp116[0]));
			
			__ammos.clear();
			for (unsigned int tmp118 = 0; tmp118 < tmp117; tmp118++)
			{
				AmmoType tmp119;
				offset++;
				char tmp121;
				tmp121 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp119 = (AmmoType) tmp121;
				
				int tmp120;
				offset++;
				tmp120 = *((int*) (&s[offset]));
				offset += sizeof(int);
				
				__ammos[tmp119] = tmp120;
			}
		}
		
		return offset;
	}
};


class Factory : public KSObject
{

protected:

	std::map<Position, Machine> __machines;
	std::map<AmmoType, std::map<MaterialType, int>> __cMixtureFormulas;
	std::map<AmmoType, int> __cConstructionDurations;
	std::map<AmmoType, int> __cAmmoBoxSizes;

	bool __has_machines;
	bool __has_cMixtureFormulas;
	bool __has_cConstructionDurations;
	bool __has_cAmmoBoxSizes;


public: // getters

	inline std::map<Position, Machine> machines() const
	{
		return __machines;
	}
	
	inline std::map<AmmoType, std::map<MaterialType, int>> cMixtureFormulas() const
	{
		return __cMixtureFormulas;
	}
	
	inline std::map<AmmoType, int> cConstructionDurations() const
	{
		return __cConstructionDurations;
	}
	
	inline std::map<AmmoType, int> cAmmoBoxSizes() const
	{
		return __cAmmoBoxSizes;
	}
	

public: // reference getters

	inline std::map<Position, Machine> &ref_machines() const
	{
		return (std::map<Position, Machine>&) __machines;
	}
	
	inline std::map<AmmoType, std::map<MaterialType, int>> &ref_cMixtureFormulas() const
	{
		return (std::map<AmmoType, std::map<MaterialType, int>>&) __cMixtureFormulas;
	}
	
	inline std::map<AmmoType, int> &ref_cConstructionDurations() const
	{
		return (std::map<AmmoType, int>&) __cConstructionDurations;
	}
	
	inline std::map<AmmoType, int> &ref_cAmmoBoxSizes() const
	{
		return (std::map<AmmoType, int>&) __cAmmoBoxSizes;
	}
	

public: // setters

	inline void machines(const std::map<Position, Machine> &machines)
	{
		__machines = machines;
		has_machines(true);
	}
	
	inline void cMixtureFormulas(const std::map<AmmoType, std::map<MaterialType, int>> &cMixtureFormulas)
	{
		__cMixtureFormulas = cMixtureFormulas;
		has_cMixtureFormulas(true);
	}
	
	inline void cConstructionDurations(const std::map<AmmoType, int> &cConstructionDurations)
	{
		__cConstructionDurations = cConstructionDurations;
		has_cConstructionDurations(true);
	}
	
	inline void cAmmoBoxSizes(const std::map<AmmoType, int> &cAmmoBoxSizes)
	{
		__cAmmoBoxSizes = cAmmoBoxSizes;
		has_cAmmoBoxSizes(true);
	}
	

public: // has_attribute getters

	inline bool has_machines() const
	{
		return __has_machines;
	}
	
	inline bool has_cMixtureFormulas() const
	{
		return __has_cMixtureFormulas;
	}
	
	inline bool has_cConstructionDurations() const
	{
		return __has_cConstructionDurations;
	}
	
	inline bool has_cAmmoBoxSizes() const
	{
		return __has_cAmmoBoxSizes;
	}
	

public: // has_attribute setters

	inline void has_machines(const bool &has_machines)
	{
		__has_machines = has_machines;
	}
	
	inline void has_cMixtureFormulas(const bool &has_cMixtureFormulas)
	{
		__has_cMixtureFormulas = has_cMixtureFormulas;
	}
	
	inline void has_cConstructionDurations(const bool &has_cConstructionDurations)
	{
		__has_cConstructionDurations = has_cConstructionDurations;
	}
	
	inline void has_cAmmoBoxSizes(const bool &has_cAmmoBoxSizes)
	{
		__has_cAmmoBoxSizes = has_cAmmoBoxSizes;
	}
	

public:

	Factory()
	{
		has_machines(false);
		has_cMixtureFormulas(false);
		has_cConstructionDurations(false);
		has_cAmmoBoxSizes(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "Factory";
	}
	
	virtual inline const std::string name() const
	{
		return "Factory";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize machines
		s += __has_machines;
		if (__has_machines)
		{
			std::string tmp122 = "";
			unsigned int tmp124 = __machines.size();
			auto tmp125 = reinterpret_cast<char*>(&tmp124);
			tmp122 += std::string(tmp125, sizeof(unsigned int));
			while (tmp122.size() && tmp122.back() == 0)
				tmp122.pop_back();
			unsigned char tmp127 = tmp122.size();
			auto tmp128 = reinterpret_cast<char*>(&tmp127);
			s += std::string(tmp128, sizeof(unsigned char));
			s += tmp122;
			
			for (auto &tmp129 : __machines)
			{
				s += '\x01';
				s += tmp129.first.serialize();
				
				s += '\x01';
				s += tmp129.second.serialize();
			}
		}
		
		// serialize cMixtureFormulas
		s += __has_cMixtureFormulas;
		if (__has_cMixtureFormulas)
		{
			std::string tmp130 = "";
			unsigned int tmp132 = __cMixtureFormulas.size();
			auto tmp133 = reinterpret_cast<char*>(&tmp132);
			tmp130 += std::string(tmp133, sizeof(unsigned int));
			while (tmp130.size() && tmp130.back() == 0)
				tmp130.pop_back();
			unsigned char tmp135 = tmp130.size();
			auto tmp136 = reinterpret_cast<char*>(&tmp135);
			s += std::string(tmp136, sizeof(unsigned char));
			s += tmp130;
			
			for (auto &tmp137 : __cMixtureFormulas)
			{
				s += '\x01';
				char tmp139 = (char) tmp137.first;
				auto tmp140 = reinterpret_cast<char*>(&tmp139);
				s += std::string(tmp140, sizeof(char));
				
				s += '\x01';
				std::string tmp141 = "";
				unsigned int tmp143 = tmp137.second.size();
				auto tmp144 = reinterpret_cast<char*>(&tmp143);
				tmp141 += std::string(tmp144, sizeof(unsigned int));
				while (tmp141.size() && tmp141.back() == 0)
					tmp141.pop_back();
				unsigned char tmp146 = tmp141.size();
				auto tmp147 = reinterpret_cast<char*>(&tmp146);
				s += std::string(tmp147, sizeof(unsigned char));
				s += tmp141;
				
				for (auto &tmp148 : tmp137.second)
				{
					s += '\x01';
					char tmp150 = (char) tmp148.first;
					auto tmp151 = reinterpret_cast<char*>(&tmp150);
					s += std::string(tmp151, sizeof(char));
					
					s += '\x01';
					int tmp153 = tmp148.second;
					auto tmp154 = reinterpret_cast<char*>(&tmp153);
					s += std::string(tmp154, sizeof(int));
				}
			}
		}
		
		// serialize cConstructionDurations
		s += __has_cConstructionDurations;
		if (__has_cConstructionDurations)
		{
			std::string tmp155 = "";
			unsigned int tmp157 = __cConstructionDurations.size();
			auto tmp158 = reinterpret_cast<char*>(&tmp157);
			tmp155 += std::string(tmp158, sizeof(unsigned int));
			while (tmp155.size() && tmp155.back() == 0)
				tmp155.pop_back();
			unsigned char tmp160 = tmp155.size();
			auto tmp161 = reinterpret_cast<char*>(&tmp160);
			s += std::string(tmp161, sizeof(unsigned char));
			s += tmp155;
			
			for (auto &tmp162 : __cConstructionDurations)
			{
				s += '\x01';
				char tmp164 = (char) tmp162.first;
				auto tmp165 = reinterpret_cast<char*>(&tmp164);
				s += std::string(tmp165, sizeof(char));
				
				s += '\x01';
				int tmp167 = tmp162.second;
				auto tmp168 = reinterpret_cast<char*>(&tmp167);
				s += std::string(tmp168, sizeof(int));
			}
		}
		
		// serialize cAmmoBoxSizes
		s += __has_cAmmoBoxSizes;
		if (__has_cAmmoBoxSizes)
		{
			std::string tmp169 = "";
			unsigned int tmp171 = __cAmmoBoxSizes.size();
			auto tmp172 = reinterpret_cast<char*>(&tmp171);
			tmp169 += std::string(tmp172, sizeof(unsigned int));
			while (tmp169.size() && tmp169.back() == 0)
				tmp169.pop_back();
			unsigned char tmp174 = tmp169.size();
			auto tmp175 = reinterpret_cast<char*>(&tmp174);
			s += std::string(tmp175, sizeof(unsigned char));
			s += tmp169;
			
			for (auto &tmp176 : __cAmmoBoxSizes)
			{
				s += '\x01';
				char tmp178 = (char) tmp176.first;
				auto tmp179 = reinterpret_cast<char*>(&tmp178);
				s += std::string(tmp179, sizeof(char));
				
				s += '\x01';
				int tmp181 = tmp176.second;
				auto tmp182 = reinterpret_cast<char*>(&tmp181);
				s += std::string(tmp182, sizeof(int));
			}
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize machines
		__has_machines = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_machines)
		{
			unsigned char tmp183;
			tmp183 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp184 = std::string(&s[offset], tmp183);
			offset += tmp183;
			while (tmp184.size() < sizeof(unsigned int))
				tmp184 += '\x00';
			unsigned int tmp185;
			tmp185 = *((unsigned int*) (&tmp184[0]));
			
			__machines.clear();
			for (unsigned int tmp186 = 0; tmp186 < tmp185; tmp186++)
			{
				Position tmp187;
				offset++;
				offset = tmp187.deserialize(s, offset);
				
				Machine tmp188;
				offset++;
				offset = tmp188.deserialize(s, offset);
				
				__machines[tmp187] = tmp188;
			}
		}
		
		// deserialize cMixtureFormulas
		__has_cMixtureFormulas = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cMixtureFormulas)
		{
			unsigned char tmp189;
			tmp189 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp190 = std::string(&s[offset], tmp189);
			offset += tmp189;
			while (tmp190.size() < sizeof(unsigned int))
				tmp190 += '\x00';
			unsigned int tmp191;
			tmp191 = *((unsigned int*) (&tmp190[0]));
			
			__cMixtureFormulas.clear();
			for (unsigned int tmp192 = 0; tmp192 < tmp191; tmp192++)
			{
				AmmoType tmp193;
				offset++;
				char tmp195;
				tmp195 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp193 = (AmmoType) tmp195;
				
				std::map<MaterialType, int> tmp194;
				offset++;
				unsigned char tmp196;
				tmp196 = *((unsigned char*) (&s[offset]));
				offset += sizeof(unsigned char);
				std::string tmp197 = std::string(&s[offset], tmp196);
				offset += tmp196;
				while (tmp197.size() < sizeof(unsigned int))
					tmp197 += '\x00';
				unsigned int tmp198;
				tmp198 = *((unsigned int*) (&tmp197[0]));
				
				tmp194.clear();
				for (unsigned int tmp199 = 0; tmp199 < tmp198; tmp199++)
				{
					MaterialType tmp200;
					offset++;
					char tmp202;
					tmp202 = *((char*) (&s[offset]));
					offset += sizeof(char);
					tmp200 = (MaterialType) tmp202;
					
					int tmp201;
					offset++;
					tmp201 = *((int*) (&s[offset]));
					offset += sizeof(int);
					
					tmp194[tmp200] = tmp201;
				}
				
				__cMixtureFormulas[tmp193] = tmp194;
			}
		}
		
		// deserialize cConstructionDurations
		__has_cConstructionDurations = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cConstructionDurations)
		{
			unsigned char tmp203;
			tmp203 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp204 = std::string(&s[offset], tmp203);
			offset += tmp203;
			while (tmp204.size() < sizeof(unsigned int))
				tmp204 += '\x00';
			unsigned int tmp205;
			tmp205 = *((unsigned int*) (&tmp204[0]));
			
			__cConstructionDurations.clear();
			for (unsigned int tmp206 = 0; tmp206 < tmp205; tmp206++)
			{
				AmmoType tmp207;
				offset++;
				char tmp209;
				tmp209 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp207 = (AmmoType) tmp209;
				
				int tmp208;
				offset++;
				tmp208 = *((int*) (&s[offset]));
				offset += sizeof(int);
				
				__cConstructionDurations[tmp207] = tmp208;
			}
		}
		
		// deserialize cAmmoBoxSizes
		__has_cAmmoBoxSizes = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cAmmoBoxSizes)
		{
			unsigned char tmp210;
			tmp210 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp211 = std::string(&s[offset], tmp210);
			offset += tmp210;
			while (tmp211.size() < sizeof(unsigned int))
				tmp211 += '\x00';
			unsigned int tmp212;
			tmp212 = *((unsigned int*) (&tmp211[0]));
			
			__cAmmoBoxSizes.clear();
			for (unsigned int tmp213 = 0; tmp213 < tmp212; tmp213++)
			{
				AmmoType tmp214;
				offset++;
				char tmp216;
				tmp216 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp214 = (AmmoType) tmp216;
				
				int tmp215;
				offset++;
				tmp215 = *((int*) (&s[offset]));
				offset += sizeof(int);
				
				__cAmmoBoxSizes[tmp214] = tmp215;
			}
		}
		
		return offset;
	}
};


class Agent : public KSObject
{

protected:

	AgentType __type;
	Position __position;
	std::map<MaterialType, int> __materialsBag;
	int __cMaterialsBagCapacity;
	std::map<AmmoType, int> __ammosBag;
	int __cAmmosBagCapacity;

	bool __has_type;
	bool __has_position;
	bool __has_materialsBag;
	bool __has_cMaterialsBagCapacity;
	bool __has_ammosBag;
	bool __has_cAmmosBagCapacity;


public: // getters

	inline AgentType type() const
	{
		return __type;
	}
	
	inline Position position() const
	{
		return __position;
	}
	
	inline std::map<MaterialType, int> materialsBag() const
	{
		return __materialsBag;
	}
	
	inline int cMaterialsBagCapacity() const
	{
		return __cMaterialsBagCapacity;
	}
	
	inline std::map<AmmoType, int> ammosBag() const
	{
		return __ammosBag;
	}
	
	inline int cAmmosBagCapacity() const
	{
		return __cAmmosBagCapacity;
	}
	

public: // reference getters

	inline AgentType &ref_type() const
	{
		return (AgentType&) __type;
	}
	
	inline Position &ref_position() const
	{
		return (Position&) __position;
	}
	
	inline std::map<MaterialType, int> &ref_materialsBag() const
	{
		return (std::map<MaterialType, int>&) __materialsBag;
	}
	
	inline int &ref_cMaterialsBagCapacity() const
	{
		return (int&) __cMaterialsBagCapacity;
	}
	
	inline std::map<AmmoType, int> &ref_ammosBag() const
	{
		return (std::map<AmmoType, int>&) __ammosBag;
	}
	
	inline int &ref_cAmmosBagCapacity() const
	{
		return (int&) __cAmmosBagCapacity;
	}
	

public: // setters

	inline void type(const AgentType &type)
	{
		__type = type;
		has_type(true);
	}
	
	inline void position(const Position &position)
	{
		__position = position;
		has_position(true);
	}
	
	inline void materialsBag(const std::map<MaterialType, int> &materialsBag)
	{
		__materialsBag = materialsBag;
		has_materialsBag(true);
	}
	
	inline void cMaterialsBagCapacity(const int &cMaterialsBagCapacity)
	{
		__cMaterialsBagCapacity = cMaterialsBagCapacity;
		has_cMaterialsBagCapacity(true);
	}
	
	inline void ammosBag(const std::map<AmmoType, int> &ammosBag)
	{
		__ammosBag = ammosBag;
		has_ammosBag(true);
	}
	
	inline void cAmmosBagCapacity(const int &cAmmosBagCapacity)
	{
		__cAmmosBagCapacity = cAmmosBagCapacity;
		has_cAmmosBagCapacity(true);
	}
	

public: // has_attribute getters

	inline bool has_type() const
	{
		return __has_type;
	}
	
	inline bool has_position() const
	{
		return __has_position;
	}
	
	inline bool has_materialsBag() const
	{
		return __has_materialsBag;
	}
	
	inline bool has_cMaterialsBagCapacity() const
	{
		return __has_cMaterialsBagCapacity;
	}
	
	inline bool has_ammosBag() const
	{
		return __has_ammosBag;
	}
	
	inline bool has_cAmmosBagCapacity() const
	{
		return __has_cAmmosBagCapacity;
	}
	

public: // has_attribute setters

	inline void has_type(const bool &has_type)
	{
		__has_type = has_type;
	}
	
	inline void has_position(const bool &has_position)
	{
		__has_position = has_position;
	}
	
	inline void has_materialsBag(const bool &has_materialsBag)
	{
		__has_materialsBag = has_materialsBag;
	}
	
	inline void has_cMaterialsBagCapacity(const bool &has_cMaterialsBagCapacity)
	{
		__has_cMaterialsBagCapacity = has_cMaterialsBagCapacity;
	}
	
	inline void has_ammosBag(const bool &has_ammosBag)
	{
		__has_ammosBag = has_ammosBag;
	}
	
	inline void has_cAmmosBagCapacity(const bool &has_cAmmosBagCapacity)
	{
		__has_cAmmosBagCapacity = has_cAmmosBagCapacity;
	}
	

public:

	Agent()
	{
		has_type(false);
		has_position(false);
		has_materialsBag(false);
		has_cMaterialsBagCapacity(false);
		has_ammosBag(false);
		has_cAmmosBagCapacity(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "Agent";
	}
	
	virtual inline const std::string name() const
	{
		return "Agent";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize type
		s += __has_type;
		if (__has_type)
		{
			char tmp218 = (char) __type;
			auto tmp219 = reinterpret_cast<char*>(&tmp218);
			s += std::string(tmp219, sizeof(char));
		}
		
		// serialize position
		s += __has_position;
		if (__has_position)
		{
			s += __position.serialize();
		}
		
		// serialize materialsBag
		s += __has_materialsBag;
		if (__has_materialsBag)
		{
			std::string tmp220 = "";
			unsigned int tmp222 = __materialsBag.size();
			auto tmp223 = reinterpret_cast<char*>(&tmp222);
			tmp220 += std::string(tmp223, sizeof(unsigned int));
			while (tmp220.size() && tmp220.back() == 0)
				tmp220.pop_back();
			unsigned char tmp225 = tmp220.size();
			auto tmp226 = reinterpret_cast<char*>(&tmp225);
			s += std::string(tmp226, sizeof(unsigned char));
			s += tmp220;
			
			for (auto &tmp227 : __materialsBag)
			{
				s += '\x01';
				char tmp229 = (char) tmp227.first;
				auto tmp230 = reinterpret_cast<char*>(&tmp229);
				s += std::string(tmp230, sizeof(char));
				
				s += '\x01';
				int tmp232 = tmp227.second;
				auto tmp233 = reinterpret_cast<char*>(&tmp232);
				s += std::string(tmp233, sizeof(int));
			}
		}
		
		// serialize cMaterialsBagCapacity
		s += __has_cMaterialsBagCapacity;
		if (__has_cMaterialsBagCapacity)
		{
			int tmp235 = __cMaterialsBagCapacity;
			auto tmp236 = reinterpret_cast<char*>(&tmp235);
			s += std::string(tmp236, sizeof(int));
		}
		
		// serialize ammosBag
		s += __has_ammosBag;
		if (__has_ammosBag)
		{
			std::string tmp237 = "";
			unsigned int tmp239 = __ammosBag.size();
			auto tmp240 = reinterpret_cast<char*>(&tmp239);
			tmp237 += std::string(tmp240, sizeof(unsigned int));
			while (tmp237.size() && tmp237.back() == 0)
				tmp237.pop_back();
			unsigned char tmp242 = tmp237.size();
			auto tmp243 = reinterpret_cast<char*>(&tmp242);
			s += std::string(tmp243, sizeof(unsigned char));
			s += tmp237;
			
			for (auto &tmp244 : __ammosBag)
			{
				s += '\x01';
				char tmp246 = (char) tmp244.first;
				auto tmp247 = reinterpret_cast<char*>(&tmp246);
				s += std::string(tmp247, sizeof(char));
				
				s += '\x01';
				int tmp249 = tmp244.second;
				auto tmp250 = reinterpret_cast<char*>(&tmp249);
				s += std::string(tmp250, sizeof(int));
			}
		}
		
		// serialize cAmmosBagCapacity
		s += __has_cAmmosBagCapacity;
		if (__has_cAmmosBagCapacity)
		{
			int tmp252 = __cAmmosBagCapacity;
			auto tmp253 = reinterpret_cast<char*>(&tmp252);
			s += std::string(tmp253, sizeof(int));
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize type
		__has_type = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_type)
		{
			char tmp254;
			tmp254 = *((char*) (&s[offset]));
			offset += sizeof(char);
			__type = (AgentType) tmp254;
		}
		
		// deserialize position
		__has_position = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_position)
		{
			offset = __position.deserialize(s, offset);
		}
		
		// deserialize materialsBag
		__has_materialsBag = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_materialsBag)
		{
			unsigned char tmp255;
			tmp255 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp256 = std::string(&s[offset], tmp255);
			offset += tmp255;
			while (tmp256.size() < sizeof(unsigned int))
				tmp256 += '\x00';
			unsigned int tmp257;
			tmp257 = *((unsigned int*) (&tmp256[0]));
			
			__materialsBag.clear();
			for (unsigned int tmp258 = 0; tmp258 < tmp257; tmp258++)
			{
				MaterialType tmp259;
				offset++;
				char tmp261;
				tmp261 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp259 = (MaterialType) tmp261;
				
				int tmp260;
				offset++;
				tmp260 = *((int*) (&s[offset]));
				offset += sizeof(int);
				
				__materialsBag[tmp259] = tmp260;
			}
		}
		
		// deserialize cMaterialsBagCapacity
		__has_cMaterialsBagCapacity = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cMaterialsBagCapacity)
		{
			__cMaterialsBagCapacity = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		// deserialize ammosBag
		__has_ammosBag = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_ammosBag)
		{
			unsigned char tmp262;
			tmp262 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp263 = std::string(&s[offset], tmp262);
			offset += tmp262;
			while (tmp263.size() < sizeof(unsigned int))
				tmp263 += '\x00';
			unsigned int tmp264;
			tmp264 = *((unsigned int*) (&tmp263[0]));
			
			__ammosBag.clear();
			for (unsigned int tmp265 = 0; tmp265 < tmp264; tmp265++)
			{
				AmmoType tmp266;
				offset++;
				char tmp268;
				tmp268 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp266 = (AmmoType) tmp268;
				
				int tmp267;
				offset++;
				tmp267 = *((int*) (&s[offset]));
				offset += sizeof(int);
				
				__ammosBag[tmp266] = tmp267;
			}
		}
		
		// deserialize cAmmosBagCapacity
		__has_cAmmosBagCapacity = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cAmmosBagCapacity)
		{
			__cAmmosBagCapacity = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		return offset;
	}
};


class Unit : public KSObject
{

protected:

	UnitType __type;
	int __health;
	int __cIndividualHealth;
	int __cIndividualDamage;
	std::map<UnitType, float> __cDamageDistribution;
	int __ammoCount;
	int __reloadRemTime;
	int __cReloadDuration;

	bool __has_type;
	bool __has_health;
	bool __has_cIndividualHealth;
	bool __has_cIndividualDamage;
	bool __has_cDamageDistribution;
	bool __has_ammoCount;
	bool __has_reloadRemTime;
	bool __has_cReloadDuration;


public: // getters

	inline UnitType type() const
	{
		return __type;
	}
	
	inline int health() const
	{
		return __health;
	}
	
	inline int cIndividualHealth() const
	{
		return __cIndividualHealth;
	}
	
	inline int cIndividualDamage() const
	{
		return __cIndividualDamage;
	}
	
	inline std::map<UnitType, float> cDamageDistribution() const
	{
		return __cDamageDistribution;
	}
	
	inline int ammoCount() const
	{
		return __ammoCount;
	}
	
	inline int reloadRemTime() const
	{
		return __reloadRemTime;
	}
	
	inline int cReloadDuration() const
	{
		return __cReloadDuration;
	}
	

public: // reference getters

	inline UnitType &ref_type() const
	{
		return (UnitType&) __type;
	}
	
	inline int &ref_health() const
	{
		return (int&) __health;
	}
	
	inline int &ref_cIndividualHealth() const
	{
		return (int&) __cIndividualHealth;
	}
	
	inline int &ref_cIndividualDamage() const
	{
		return (int&) __cIndividualDamage;
	}
	
	inline std::map<UnitType, float> &ref_cDamageDistribution() const
	{
		return (std::map<UnitType, float>&) __cDamageDistribution;
	}
	
	inline int &ref_ammoCount() const
	{
		return (int&) __ammoCount;
	}
	
	inline int &ref_reloadRemTime() const
	{
		return (int&) __reloadRemTime;
	}
	
	inline int &ref_cReloadDuration() const
	{
		return (int&) __cReloadDuration;
	}
	

public: // setters

	inline void type(const UnitType &type)
	{
		__type = type;
		has_type(true);
	}
	
	inline void health(const int &health)
	{
		__health = health;
		has_health(true);
	}
	
	inline void cIndividualHealth(const int &cIndividualHealth)
	{
		__cIndividualHealth = cIndividualHealth;
		has_cIndividualHealth(true);
	}
	
	inline void cIndividualDamage(const int &cIndividualDamage)
	{
		__cIndividualDamage = cIndividualDamage;
		has_cIndividualDamage(true);
	}
	
	inline void cDamageDistribution(const std::map<UnitType, float> &cDamageDistribution)
	{
		__cDamageDistribution = cDamageDistribution;
		has_cDamageDistribution(true);
	}
	
	inline void ammoCount(const int &ammoCount)
	{
		__ammoCount = ammoCount;
		has_ammoCount(true);
	}
	
	inline void reloadRemTime(const int &reloadRemTime)
	{
		__reloadRemTime = reloadRemTime;
		has_reloadRemTime(true);
	}
	
	inline void cReloadDuration(const int &cReloadDuration)
	{
		__cReloadDuration = cReloadDuration;
		has_cReloadDuration(true);
	}
	

public: // has_attribute getters

	inline bool has_type() const
	{
		return __has_type;
	}
	
	inline bool has_health() const
	{
		return __has_health;
	}
	
	inline bool has_cIndividualHealth() const
	{
		return __has_cIndividualHealth;
	}
	
	inline bool has_cIndividualDamage() const
	{
		return __has_cIndividualDamage;
	}
	
	inline bool has_cDamageDistribution() const
	{
		return __has_cDamageDistribution;
	}
	
	inline bool has_ammoCount() const
	{
		return __has_ammoCount;
	}
	
	inline bool has_reloadRemTime() const
	{
		return __has_reloadRemTime;
	}
	
	inline bool has_cReloadDuration() const
	{
		return __has_cReloadDuration;
	}
	

public: // has_attribute setters

	inline void has_type(const bool &has_type)
	{
		__has_type = has_type;
	}
	
	inline void has_health(const bool &has_health)
	{
		__has_health = has_health;
	}
	
	inline void has_cIndividualHealth(const bool &has_cIndividualHealth)
	{
		__has_cIndividualHealth = has_cIndividualHealth;
	}
	
	inline void has_cIndividualDamage(const bool &has_cIndividualDamage)
	{
		__has_cIndividualDamage = has_cIndividualDamage;
	}
	
	inline void has_cDamageDistribution(const bool &has_cDamageDistribution)
	{
		__has_cDamageDistribution = has_cDamageDistribution;
	}
	
	inline void has_ammoCount(const bool &has_ammoCount)
	{
		__has_ammoCount = has_ammoCount;
	}
	
	inline void has_reloadRemTime(const bool &has_reloadRemTime)
	{
		__has_reloadRemTime = has_reloadRemTime;
	}
	
	inline void has_cReloadDuration(const bool &has_cReloadDuration)
	{
		__has_cReloadDuration = has_cReloadDuration;
	}
	

public:

	Unit()
	{
		has_type(false);
		has_health(false);
		has_cIndividualHealth(false);
		has_cIndividualDamage(false);
		has_cDamageDistribution(false);
		has_ammoCount(false);
		has_reloadRemTime(false);
		has_cReloadDuration(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "Unit";
	}
	
	virtual inline const std::string name() const
	{
		return "Unit";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize type
		s += __has_type;
		if (__has_type)
		{
			char tmp270 = (char) __type;
			auto tmp271 = reinterpret_cast<char*>(&tmp270);
			s += std::string(tmp271, sizeof(char));
		}
		
		// serialize health
		s += __has_health;
		if (__has_health)
		{
			int tmp273 = __health;
			auto tmp274 = reinterpret_cast<char*>(&tmp273);
			s += std::string(tmp274, sizeof(int));
		}
		
		// serialize cIndividualHealth
		s += __has_cIndividualHealth;
		if (__has_cIndividualHealth)
		{
			int tmp276 = __cIndividualHealth;
			auto tmp277 = reinterpret_cast<char*>(&tmp276);
			s += std::string(tmp277, sizeof(int));
		}
		
		// serialize cIndividualDamage
		s += __has_cIndividualDamage;
		if (__has_cIndividualDamage)
		{
			int tmp279 = __cIndividualDamage;
			auto tmp280 = reinterpret_cast<char*>(&tmp279);
			s += std::string(tmp280, sizeof(int));
		}
		
		// serialize cDamageDistribution
		s += __has_cDamageDistribution;
		if (__has_cDamageDistribution)
		{
			std::string tmp281 = "";
			unsigned int tmp283 = __cDamageDistribution.size();
			auto tmp284 = reinterpret_cast<char*>(&tmp283);
			tmp281 += std::string(tmp284, sizeof(unsigned int));
			while (tmp281.size() && tmp281.back() == 0)
				tmp281.pop_back();
			unsigned char tmp286 = tmp281.size();
			auto tmp287 = reinterpret_cast<char*>(&tmp286);
			s += std::string(tmp287, sizeof(unsigned char));
			s += tmp281;
			
			for (auto &tmp288 : __cDamageDistribution)
			{
				s += '\x01';
				char tmp290 = (char) tmp288.first;
				auto tmp291 = reinterpret_cast<char*>(&tmp290);
				s += std::string(tmp291, sizeof(char));
				
				s += '\x01';
				float tmp293 = tmp288.second;
				auto tmp294 = reinterpret_cast<char*>(&tmp293);
				s += std::string(tmp294, sizeof(float));
			}
		}
		
		// serialize ammoCount
		s += __has_ammoCount;
		if (__has_ammoCount)
		{
			int tmp296 = __ammoCount;
			auto tmp297 = reinterpret_cast<char*>(&tmp296);
			s += std::string(tmp297, sizeof(int));
		}
		
		// serialize reloadRemTime
		s += __has_reloadRemTime;
		if (__has_reloadRemTime)
		{
			int tmp299 = __reloadRemTime;
			auto tmp300 = reinterpret_cast<char*>(&tmp299);
			s += std::string(tmp300, sizeof(int));
		}
		
		// serialize cReloadDuration
		s += __has_cReloadDuration;
		if (__has_cReloadDuration)
		{
			int tmp302 = __cReloadDuration;
			auto tmp303 = reinterpret_cast<char*>(&tmp302);
			s += std::string(tmp303, sizeof(int));
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize type
		__has_type = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_type)
		{
			char tmp304;
			tmp304 = *((char*) (&s[offset]));
			offset += sizeof(char);
			__type = (UnitType) tmp304;
		}
		
		// deserialize health
		__has_health = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_health)
		{
			__health = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		// deserialize cIndividualHealth
		__has_cIndividualHealth = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cIndividualHealth)
		{
			__cIndividualHealth = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		// deserialize cIndividualDamage
		__has_cIndividualDamage = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cIndividualDamage)
		{
			__cIndividualDamage = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		// deserialize cDamageDistribution
		__has_cDamageDistribution = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cDamageDistribution)
		{
			unsigned char tmp305;
			tmp305 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp306 = std::string(&s[offset], tmp305);
			offset += tmp305;
			while (tmp306.size() < sizeof(unsigned int))
				tmp306 += '\x00';
			unsigned int tmp307;
			tmp307 = *((unsigned int*) (&tmp306[0]));
			
			__cDamageDistribution.clear();
			for (unsigned int tmp308 = 0; tmp308 < tmp307; tmp308++)
			{
				UnitType tmp309;
				offset++;
				char tmp311;
				tmp311 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp309 = (UnitType) tmp311;
				
				float tmp310;
				offset++;
				tmp310 = *((float*) (&s[offset]));
				offset += sizeof(float);
				
				__cDamageDistribution[tmp309] = tmp310;
			}
		}
		
		// deserialize ammoCount
		__has_ammoCount = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_ammoCount)
		{
			__ammoCount = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		// deserialize reloadRemTime
		__has_reloadRemTime = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_reloadRemTime)
		{
			__reloadRemTime = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		// deserialize cReloadDuration
		__has_cReloadDuration = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cReloadDuration)
		{
			__cReloadDuration = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		return offset;
	}
};


class Base : public KSObject
{

protected:

	std::vector<ECell> __cArea;
	std::map<AgentType, Agent> __agents;
	FrontlineDelivery __frontlineDelivery;
	Repository __repository;
	BacklineDelivery __backlineDelivery;
	Factory __factory;
	std::map<UnitType, Unit> __units;

	bool __has_cArea;
	bool __has_agents;
	bool __has_frontlineDelivery;
	bool __has_repository;
	bool __has_backlineDelivery;
	bool __has_factory;
	bool __has_units;


public: // getters

	inline std::vector<ECell> cArea() const
	{
		return __cArea;
	}
	
	inline std::map<AgentType, Agent> agents() const
	{
		return __agents;
	}
	
	inline FrontlineDelivery frontlineDelivery() const
	{
		return __frontlineDelivery;
	}
	
	inline Repository repository() const
	{
		return __repository;
	}
	
	inline BacklineDelivery backlineDelivery() const
	{
		return __backlineDelivery;
	}
	
	inline Factory factory() const
	{
		return __factory;
	}
	
	inline std::map<UnitType, Unit> units() const
	{
		return __units;
	}
	

public: // reference getters

	inline std::vector<ECell> &ref_cArea() const
	{
		return (std::vector<ECell>&) __cArea;
	}
	
	inline std::map<AgentType, Agent> &ref_agents() const
	{
		return (std::map<AgentType, Agent>&) __agents;
	}
	
	inline FrontlineDelivery &ref_frontlineDelivery() const
	{
		return (FrontlineDelivery&) __frontlineDelivery;
	}
	
	inline Repository &ref_repository() const
	{
		return (Repository&) __repository;
	}
	
	inline BacklineDelivery &ref_backlineDelivery() const
	{
		return (BacklineDelivery&) __backlineDelivery;
	}
	
	inline Factory &ref_factory() const
	{
		return (Factory&) __factory;
	}
	
	inline std::map<UnitType, Unit> &ref_units() const
	{
		return (std::map<UnitType, Unit>&) __units;
	}
	

public: // setters

	inline void cArea(const std::vector<ECell> &cArea)
	{
		__cArea = cArea;
		has_cArea(true);
	}
	
	inline void agents(const std::map<AgentType, Agent> &agents)
	{
		__agents = agents;
		has_agents(true);
	}
	
	inline void frontlineDelivery(const FrontlineDelivery &frontlineDelivery)
	{
		__frontlineDelivery = frontlineDelivery;
		has_frontlineDelivery(true);
	}
	
	inline void repository(const Repository &repository)
	{
		__repository = repository;
		has_repository(true);
	}
	
	inline void backlineDelivery(const BacklineDelivery &backlineDelivery)
	{
		__backlineDelivery = backlineDelivery;
		has_backlineDelivery(true);
	}
	
	inline void factory(const Factory &factory)
	{
		__factory = factory;
		has_factory(true);
	}
	
	inline void units(const std::map<UnitType, Unit> &units)
	{
		__units = units;
		has_units(true);
	}
	

public: // has_attribute getters

	inline bool has_cArea() const
	{
		return __has_cArea;
	}
	
	inline bool has_agents() const
	{
		return __has_agents;
	}
	
	inline bool has_frontlineDelivery() const
	{
		return __has_frontlineDelivery;
	}
	
	inline bool has_repository() const
	{
		return __has_repository;
	}
	
	inline bool has_backlineDelivery() const
	{
		return __has_backlineDelivery;
	}
	
	inline bool has_factory() const
	{
		return __has_factory;
	}
	
	inline bool has_units() const
	{
		return __has_units;
	}
	

public: // has_attribute setters

	inline void has_cArea(const bool &has_cArea)
	{
		__has_cArea = has_cArea;
	}
	
	inline void has_agents(const bool &has_agents)
	{
		__has_agents = has_agents;
	}
	
	inline void has_frontlineDelivery(const bool &has_frontlineDelivery)
	{
		__has_frontlineDelivery = has_frontlineDelivery;
	}
	
	inline void has_repository(const bool &has_repository)
	{
		__has_repository = has_repository;
	}
	
	inline void has_backlineDelivery(const bool &has_backlineDelivery)
	{
		__has_backlineDelivery = has_backlineDelivery;
	}
	
	inline void has_factory(const bool &has_factory)
	{
		__has_factory = has_factory;
	}
	
	inline void has_units(const bool &has_units)
	{
		__has_units = has_units;
	}
	

public:

	Base()
	{
		has_cArea(false);
		has_agents(false);
		has_frontlineDelivery(false);
		has_repository(false);
		has_backlineDelivery(false);
		has_factory(false);
		has_units(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "Base";
	}
	
	virtual inline const std::string name() const
	{
		return "Base";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize cArea
		s += __has_cArea;
		if (__has_cArea)
		{
			std::string tmp312 = "";
			unsigned int tmp314 = __cArea.size();
			auto tmp315 = reinterpret_cast<char*>(&tmp314);
			tmp312 += std::string(tmp315, sizeof(unsigned int));
			while (tmp312.size() && tmp312.back() == 0)
				tmp312.pop_back();
			unsigned char tmp317 = tmp312.size();
			auto tmp318 = reinterpret_cast<char*>(&tmp317);
			s += std::string(tmp318, sizeof(unsigned char));
			s += tmp312;
			
			for (auto &tmp319 : __cArea)
			{
				s += '\x01';
				char tmp321 = (char) tmp319;
				auto tmp322 = reinterpret_cast<char*>(&tmp321);
				s += std::string(tmp322, sizeof(char));
			}
		}
		
		// serialize agents
		s += __has_agents;
		if (__has_agents)
		{
			std::string tmp323 = "";
			unsigned int tmp325 = __agents.size();
			auto tmp326 = reinterpret_cast<char*>(&tmp325);
			tmp323 += std::string(tmp326, sizeof(unsigned int));
			while (tmp323.size() && tmp323.back() == 0)
				tmp323.pop_back();
			unsigned char tmp328 = tmp323.size();
			auto tmp329 = reinterpret_cast<char*>(&tmp328);
			s += std::string(tmp329, sizeof(unsigned char));
			s += tmp323;
			
			for (auto &tmp330 : __agents)
			{
				s += '\x01';
				char tmp332 = (char) tmp330.first;
				auto tmp333 = reinterpret_cast<char*>(&tmp332);
				s += std::string(tmp333, sizeof(char));
				
				s += '\x01';
				s += tmp330.second.serialize();
			}
		}
		
		// serialize frontlineDelivery
		s += __has_frontlineDelivery;
		if (__has_frontlineDelivery)
		{
			s += __frontlineDelivery.serialize();
		}
		
		// serialize repository
		s += __has_repository;
		if (__has_repository)
		{
			s += __repository.serialize();
		}
		
		// serialize backlineDelivery
		s += __has_backlineDelivery;
		if (__has_backlineDelivery)
		{
			s += __backlineDelivery.serialize();
		}
		
		// serialize factory
		s += __has_factory;
		if (__has_factory)
		{
			s += __factory.serialize();
		}
		
		// serialize units
		s += __has_units;
		if (__has_units)
		{
			std::string tmp334 = "";
			unsigned int tmp336 = __units.size();
			auto tmp337 = reinterpret_cast<char*>(&tmp336);
			tmp334 += std::string(tmp337, sizeof(unsigned int));
			while (tmp334.size() && tmp334.back() == 0)
				tmp334.pop_back();
			unsigned char tmp339 = tmp334.size();
			auto tmp340 = reinterpret_cast<char*>(&tmp339);
			s += std::string(tmp340, sizeof(unsigned char));
			s += tmp334;
			
			for (auto &tmp341 : __units)
			{
				s += '\x01';
				char tmp343 = (char) tmp341.first;
				auto tmp344 = reinterpret_cast<char*>(&tmp343);
				s += std::string(tmp344, sizeof(char));
				
				s += '\x01';
				s += tmp341.second.serialize();
			}
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize cArea
		__has_cArea = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_cArea)
		{
			unsigned char tmp345;
			tmp345 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp346 = std::string(&s[offset], tmp345);
			offset += tmp345;
			while (tmp346.size() < sizeof(unsigned int))
				tmp346 += '\x00';
			unsigned int tmp347;
			tmp347 = *((unsigned int*) (&tmp346[0]));
			
			__cArea.clear();
			for (unsigned int tmp348 = 0; tmp348 < tmp347; tmp348++)
			{
				ECell tmp349;
				offset++;
				char tmp350;
				tmp350 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp349 = (ECell) tmp350;
				__cArea.push_back(tmp349);
			}
		}
		
		// deserialize agents
		__has_agents = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_agents)
		{
			unsigned char tmp351;
			tmp351 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp352 = std::string(&s[offset], tmp351);
			offset += tmp351;
			while (tmp352.size() < sizeof(unsigned int))
				tmp352 += '\x00';
			unsigned int tmp353;
			tmp353 = *((unsigned int*) (&tmp352[0]));
			
			__agents.clear();
			for (unsigned int tmp354 = 0; tmp354 < tmp353; tmp354++)
			{
				AgentType tmp355;
				offset++;
				char tmp357;
				tmp357 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp355 = (AgentType) tmp357;
				
				Agent tmp356;
				offset++;
				offset = tmp356.deserialize(s, offset);
				
				__agents[tmp355] = tmp356;
			}
		}
		
		// deserialize frontlineDelivery
		__has_frontlineDelivery = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_frontlineDelivery)
		{
			offset = __frontlineDelivery.deserialize(s, offset);
		}
		
		// deserialize repository
		__has_repository = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_repository)
		{
			offset = __repository.deserialize(s, offset);
		}
		
		// deserialize backlineDelivery
		__has_backlineDelivery = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_backlineDelivery)
		{
			offset = __backlineDelivery.deserialize(s, offset);
		}
		
		// deserialize factory
		__has_factory = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_factory)
		{
			offset = __factory.deserialize(s, offset);
		}
		
		// deserialize units
		__has_units = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_units)
		{
			unsigned char tmp358;
			tmp358 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp359 = std::string(&s[offset], tmp358);
			offset += tmp358;
			while (tmp359.size() < sizeof(unsigned int))
				tmp359 += '\x00';
			unsigned int tmp360;
			tmp360 = *((unsigned int*) (&tmp359[0]));
			
			__units.clear();
			for (unsigned int tmp361 = 0; tmp361 < tmp360; tmp361++)
			{
				UnitType tmp362;
				offset++;
				char tmp364;
				tmp364 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp362 = (UnitType) tmp364;
				
				Unit tmp363;
				offset++;
				offset = tmp363.deserialize(s, offset);
				
				__units[tmp362] = tmp363;
			}
		}
		
		return offset;
	}
};


class World : public KSObject
{

protected:

	int __maxCycles;
	std::map<std::string, Base> __bases;
	std::map<std::string, int> __totalHealths;

	bool __has_maxCycles;
	bool __has_bases;
	bool __has_totalHealths;


public: // getters

	inline int maxCycles() const
	{
		return __maxCycles;
	}
	
	inline std::map<std::string, Base> bases() const
	{
		return __bases;
	}
	
	inline std::map<std::string, int> totalHealths() const
	{
		return __totalHealths;
	}
	

public: // reference getters

	inline int &ref_maxCycles() const
	{
		return (int&) __maxCycles;
	}
	
	inline std::map<std::string, Base> &ref_bases() const
	{
		return (std::map<std::string, Base>&) __bases;
	}
	
	inline std::map<std::string, int> &ref_totalHealths() const
	{
		return (std::map<std::string, int>&) __totalHealths;
	}
	

public: // setters

	inline void maxCycles(const int &maxCycles)
	{
		__maxCycles = maxCycles;
		has_maxCycles(true);
	}
	
	inline void bases(const std::map<std::string, Base> &bases)
	{
		__bases = bases;
		has_bases(true);
	}
	
	inline void totalHealths(const std::map<std::string, int> &totalHealths)
	{
		__totalHealths = totalHealths;
		has_totalHealths(true);
	}
	

public: // has_attribute getters

	inline bool has_maxCycles() const
	{
		return __has_maxCycles;
	}
	
	inline bool has_bases() const
	{
		return __has_bases;
	}
	
	inline bool has_totalHealths() const
	{
		return __has_totalHealths;
	}
	

public: // has_attribute setters

	inline void has_maxCycles(const bool &has_maxCycles)
	{
		__has_maxCycles = has_maxCycles;
	}
	
	inline void has_bases(const bool &has_bases)
	{
		__has_bases = has_bases;
	}
	
	inline void has_totalHealths(const bool &has_totalHealths)
	{
		__has_totalHealths = has_totalHealths;
	}
	

public:

	World()
	{
		has_maxCycles(false);
		has_bases(false);
		has_totalHealths(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "World";
	}
	
	virtual inline const std::string name() const
	{
		return "World";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize maxCycles
		s += __has_maxCycles;
		if (__has_maxCycles)
		{
			int tmp366 = __maxCycles;
			auto tmp367 = reinterpret_cast<char*>(&tmp366);
			s += std::string(tmp367, sizeof(int));
		}
		
		// serialize bases
		s += __has_bases;
		if (__has_bases)
		{
			std::string tmp368 = "";
			unsigned int tmp370 = __bases.size();
			auto tmp371 = reinterpret_cast<char*>(&tmp370);
			tmp368 += std::string(tmp371, sizeof(unsigned int));
			while (tmp368.size() && tmp368.back() == 0)
				tmp368.pop_back();
			unsigned char tmp373 = tmp368.size();
			auto tmp374 = reinterpret_cast<char*>(&tmp373);
			s += std::string(tmp374, sizeof(unsigned char));
			s += tmp368;
			
			for (auto &tmp375 : __bases)
			{
				s += '\x01';
				std::string tmp376 = "";
				unsigned int tmp378 = tmp375.first.size();
				auto tmp379 = reinterpret_cast<char*>(&tmp378);
				tmp376 += std::string(tmp379, sizeof(unsigned int));
				while (tmp376.size() && tmp376.back() == 0)
					tmp376.pop_back();
				unsigned char tmp381 = tmp376.size();
				auto tmp382 = reinterpret_cast<char*>(&tmp381);
				s += std::string(tmp382, sizeof(unsigned char));
				s += tmp376;
				
				s += tmp375.first;
				
				s += '\x01';
				s += tmp375.second.serialize();
			}
		}
		
		// serialize totalHealths
		s += __has_totalHealths;
		if (__has_totalHealths)
		{
			std::string tmp383 = "";
			unsigned int tmp385 = __totalHealths.size();
			auto tmp386 = reinterpret_cast<char*>(&tmp385);
			tmp383 += std::string(tmp386, sizeof(unsigned int));
			while (tmp383.size() && tmp383.back() == 0)
				tmp383.pop_back();
			unsigned char tmp388 = tmp383.size();
			auto tmp389 = reinterpret_cast<char*>(&tmp388);
			s += std::string(tmp389, sizeof(unsigned char));
			s += tmp383;
			
			for (auto &tmp390 : __totalHealths)
			{
				s += '\x01';
				std::string tmp391 = "";
				unsigned int tmp393 = tmp390.first.size();
				auto tmp394 = reinterpret_cast<char*>(&tmp393);
				tmp391 += std::string(tmp394, sizeof(unsigned int));
				while (tmp391.size() && tmp391.back() == 0)
					tmp391.pop_back();
				unsigned char tmp396 = tmp391.size();
				auto tmp397 = reinterpret_cast<char*>(&tmp396);
				s += std::string(tmp397, sizeof(unsigned char));
				s += tmp391;
				
				s += tmp390.first;
				
				s += '\x01';
				int tmp399 = tmp390.second;
				auto tmp400 = reinterpret_cast<char*>(&tmp399);
				s += std::string(tmp400, sizeof(int));
			}
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize maxCycles
		__has_maxCycles = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_maxCycles)
		{
			__maxCycles = *((int*) (&s[offset]));
			offset += sizeof(int);
		}
		
		// deserialize bases
		__has_bases = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_bases)
		{
			unsigned char tmp401;
			tmp401 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp402 = std::string(&s[offset], tmp401);
			offset += tmp401;
			while (tmp402.size() < sizeof(unsigned int))
				tmp402 += '\x00';
			unsigned int tmp403;
			tmp403 = *((unsigned int*) (&tmp402[0]));
			
			__bases.clear();
			for (unsigned int tmp404 = 0; tmp404 < tmp403; tmp404++)
			{
				std::string tmp405;
				offset++;
				unsigned char tmp407;
				tmp407 = *((unsigned char*) (&s[offset]));
				offset += sizeof(unsigned char);
				std::string tmp408 = std::string(&s[offset], tmp407);
				offset += tmp407;
				while (tmp408.size() < sizeof(unsigned int))
					tmp408 += '\x00';
				unsigned int tmp409;
				tmp409 = *((unsigned int*) (&tmp408[0]));
				
				tmp405 = s.substr(offset, tmp409);
				offset += tmp409;
				
				Base tmp406;
				offset++;
				offset = tmp406.deserialize(s, offset);
				
				__bases[tmp405] = tmp406;
			}
		}
		
		// deserialize totalHealths
		__has_totalHealths = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_totalHealths)
		{
			unsigned char tmp410;
			tmp410 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp411 = std::string(&s[offset], tmp410);
			offset += tmp410;
			while (tmp411.size() < sizeof(unsigned int))
				tmp411 += '\x00';
			unsigned int tmp412;
			tmp412 = *((unsigned int*) (&tmp411[0]));
			
			__totalHealths.clear();
			for (unsigned int tmp413 = 0; tmp413 < tmp412; tmp413++)
			{
				std::string tmp414;
				offset++;
				unsigned char tmp416;
				tmp416 = *((unsigned char*) (&s[offset]));
				offset += sizeof(unsigned char);
				std::string tmp417 = std::string(&s[offset], tmp416);
				offset += tmp416;
				while (tmp417.size() < sizeof(unsigned int))
					tmp417 += '\x00';
				unsigned int tmp418;
				tmp418 = *((unsigned int*) (&tmp417[0]));
				
				tmp414 = s.substr(offset, tmp418);
				offset += tmp418;
				
				int tmp415;
				offset++;
				tmp415 = *((int*) (&s[offset]));
				offset += sizeof(int);
				
				__totalHealths[tmp414] = tmp415;
			}
		}
		
		return offset;
	}
};

} // namespace models

} // namespace ks

#endif // _KS_MODELS_H_
