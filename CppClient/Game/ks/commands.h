#ifndef _KS_COMMANDS_H_
#define _KS_COMMANDS_H_

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


namespace commands
{

enum class CommandMaterialType
{
	Powder = 0,
	Steel = 1,
	Aluminum = 2,
	Shell = 3,
	Nickel = 4,
	Manganese = 5,
	Chromium = 6,
};


enum class CommandAmmoType
{
	RifleBullet = 0,
	TankShell = 1,
	Bomb = 2,
	ArtilleryShell = 3,
	HMGBullet = 4,
};


enum class CommandAgentType
{
	Repository = 0,
	Factory = 1,
};


class BaseCommand : public KSObject
{

protected:

	CommandAgentType __agentType;

	bool __has_agentType;


public: // getters

	inline CommandAgentType agentType() const
	{
		return __agentType;
	}
	

public: // reference getters

	inline CommandAgentType &ref_agentType() const
	{
		return (CommandAgentType&) __agentType;
	}
	

public: // setters

	inline void agentType(const CommandAgentType &agentType)
	{
		__agentType = agentType;
		has_agentType(true);
	}
	

public: // has_attribute getters

	inline bool has_agentType() const
	{
		return __has_agentType;
	}
	

public: // has_attribute setters

	inline void has_agentType(const bool &has_agentType)
	{
		__has_agentType = has_agentType;
	}
	

public:

	BaseCommand()
	{
		has_agentType(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "BaseCommand";
	}
	
	virtual inline const std::string name() const
	{
		return "BaseCommand";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize agentType
		s += __has_agentType;
		if (__has_agentType)
		{
			char tmp1 = (char) __agentType;
			auto tmp2 = reinterpret_cast<char*>(&tmp1);
			s += std::string(tmp2, sizeof(char));
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize agentType
		__has_agentType = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_agentType)
		{
			char tmp3;
			tmp3 = *((char*) (&s[offset]));
			offset += sizeof(char);
			__agentType = (CommandAgentType) tmp3;
		}
		
		return offset;
	}
};


class Move : public BaseCommand
{

protected:

	bool __forward;

	bool __has_forward;


public: // getters

	inline bool forward() const
	{
		return __forward;
	}
	

public: // reference getters

	inline bool &ref_forward() const
	{
		return (bool&) __forward;
	}
	

public: // setters

	inline void forward(const bool &forward)
	{
		__forward = forward;
		has_forward(true);
	}
	

public: // has_attribute getters

	inline bool has_forward() const
	{
		return __has_forward;
	}
	

public: // has_attribute setters

	inline void has_forward(const bool &has_forward)
	{
		__has_forward = has_forward;
	}
	

public:

	Move()
	{
		has_forward(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "Move";
	}
	
	virtual inline const std::string name() const
	{
		return "Move";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize parents
		s += BaseCommand::serialize();
		
		// serialize forward
		s += __has_forward;
		if (__has_forward)
		{
			bool tmp5 = __forward;
			auto tmp6 = reinterpret_cast<char*>(&tmp5);
			s += std::string(tmp6, sizeof(bool));
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize parents
		offset = BaseCommand::deserialize(s, offset);
		
		// deserialize forward
		__has_forward = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_forward)
		{
			__forward = *((bool*) (&s[offset]));
			offset += sizeof(bool);
		}
		
		return offset;
	}
};


class PickMaterial : public BaseCommand
{

protected:

	std::map<CommandMaterialType, int> __materials;

	bool __has_materials;


public: // getters

	inline std::map<CommandMaterialType, int> materials() const
	{
		return __materials;
	}
	

public: // reference getters

	inline std::map<CommandMaterialType, int> &ref_materials() const
	{
		return (std::map<CommandMaterialType, int>&) __materials;
	}
	

public: // setters

	inline void materials(const std::map<CommandMaterialType, int> &materials)
	{
		__materials = materials;
		has_materials(true);
	}
	

public: // has_attribute getters

	inline bool has_materials() const
	{
		return __has_materials;
	}
	

public: // has_attribute setters

	inline void has_materials(const bool &has_materials)
	{
		__has_materials = has_materials;
	}
	

public:

	PickMaterial()
	{
		has_materials(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "PickMaterial";
	}
	
	virtual inline const std::string name() const
	{
		return "PickMaterial";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize parents
		s += BaseCommand::serialize();
		
		// serialize materials
		s += __has_materials;
		if (__has_materials)
		{
			std::string tmp7 = "";
			unsigned int tmp9 = __materials.size();
			auto tmp10 = reinterpret_cast<char*>(&tmp9);
			tmp7 += std::string(tmp10, sizeof(unsigned int));
			while (tmp7.size() && tmp7.back() == 0)
				tmp7.pop_back();
			unsigned char tmp12 = tmp7.size();
			auto tmp13 = reinterpret_cast<char*>(&tmp12);
			s += std::string(tmp13, sizeof(unsigned char));
			s += tmp7;
			
			for (auto &tmp14 : __materials)
			{
				s += '\x01';
				char tmp16 = (char) tmp14.first;
				auto tmp17 = reinterpret_cast<char*>(&tmp16);
				s += std::string(tmp17, sizeof(char));
				
				s += '\x01';
				int tmp19 = tmp14.second;
				auto tmp20 = reinterpret_cast<char*>(&tmp19);
				s += std::string(tmp20, sizeof(int));
			}
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize parents
		offset = BaseCommand::deserialize(s, offset);
		
		// deserialize materials
		__has_materials = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_materials)
		{
			unsigned char tmp21;
			tmp21 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp22 = std::string(&s[offset], tmp21);
			offset += tmp21;
			while (tmp22.size() < sizeof(unsigned int))
				tmp22 += '\x00';
			unsigned int tmp23;
			tmp23 = *((unsigned int*) (&tmp22[0]));
			
			__materials.clear();
			for (unsigned int tmp24 = 0; tmp24 < tmp23; tmp24++)
			{
				CommandMaterialType tmp25;
				offset++;
				char tmp27;
				tmp27 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp25 = (CommandMaterialType) tmp27;
				
				int tmp26;
				offset++;
				tmp26 = *((int*) (&s[offset]));
				offset += sizeof(int);
				
				__materials[tmp25] = tmp26;
			}
		}
		
		return offset;
	}
};


class PutMaterial : public BaseCommand
{

protected:

	std::map<CommandMaterialType, int> __materials;

	bool __has_materials;


public: // getters

	inline std::map<CommandMaterialType, int> materials() const
	{
		return __materials;
	}
	

public: // reference getters

	inline std::map<CommandMaterialType, int> &ref_materials() const
	{
		return (std::map<CommandMaterialType, int>&) __materials;
	}
	

public: // setters

	inline void materials(const std::map<CommandMaterialType, int> &materials)
	{
		__materials = materials;
		has_materials(true);
	}
	

public: // has_attribute getters

	inline bool has_materials() const
	{
		return __has_materials;
	}
	

public: // has_attribute setters

	inline void has_materials(const bool &has_materials)
	{
		__has_materials = has_materials;
	}
	

public:

	PutMaterial()
	{
		has_materials(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "PutMaterial";
	}
	
	virtual inline const std::string name() const
	{
		return "PutMaterial";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize parents
		s += BaseCommand::serialize();
		
		// serialize materials
		s += __has_materials;
		if (__has_materials)
		{
			std::string tmp28 = "";
			unsigned int tmp30 = __materials.size();
			auto tmp31 = reinterpret_cast<char*>(&tmp30);
			tmp28 += std::string(tmp31, sizeof(unsigned int));
			while (tmp28.size() && tmp28.back() == 0)
				tmp28.pop_back();
			unsigned char tmp33 = tmp28.size();
			auto tmp34 = reinterpret_cast<char*>(&tmp33);
			s += std::string(tmp34, sizeof(unsigned char));
			s += tmp28;
			
			for (auto &tmp35 : __materials)
			{
				s += '\x01';
				char tmp37 = (char) tmp35.first;
				auto tmp38 = reinterpret_cast<char*>(&tmp37);
				s += std::string(tmp38, sizeof(char));
				
				s += '\x01';
				int tmp40 = tmp35.second;
				auto tmp41 = reinterpret_cast<char*>(&tmp40);
				s += std::string(tmp41, sizeof(int));
			}
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize parents
		offset = BaseCommand::deserialize(s, offset);
		
		// deserialize materials
		__has_materials = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_materials)
		{
			unsigned char tmp42;
			tmp42 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp43 = std::string(&s[offset], tmp42);
			offset += tmp42;
			while (tmp43.size() < sizeof(unsigned int))
				tmp43 += '\x00';
			unsigned int tmp44;
			tmp44 = *((unsigned int*) (&tmp43[0]));
			
			__materials.clear();
			for (unsigned int tmp45 = 0; tmp45 < tmp44; tmp45++)
			{
				CommandMaterialType tmp46;
				offset++;
				char tmp48;
				tmp48 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp46 = (CommandMaterialType) tmp48;
				
				int tmp47;
				offset++;
				tmp47 = *((int*) (&s[offset]));
				offset += sizeof(int);
				
				__materials[tmp46] = tmp47;
			}
		}
		
		return offset;
	}
};


class PickAmmo : public BaseCommand
{

protected:

	std::map<CommandAmmoType, int> __ammos;

	bool __has_ammos;


public: // getters

	inline std::map<CommandAmmoType, int> ammos() const
	{
		return __ammos;
	}
	

public: // reference getters

	inline std::map<CommandAmmoType, int> &ref_ammos() const
	{
		return (std::map<CommandAmmoType, int>&) __ammos;
	}
	

public: // setters

	inline void ammos(const std::map<CommandAmmoType, int> &ammos)
	{
		__ammos = ammos;
		has_ammos(true);
	}
	

public: // has_attribute getters

	inline bool has_ammos() const
	{
		return __has_ammos;
	}
	

public: // has_attribute setters

	inline void has_ammos(const bool &has_ammos)
	{
		__has_ammos = has_ammos;
	}
	

public:

	PickAmmo()
	{
		has_ammos(false);
	}
	
	static inline const std::string nameStatic()
	{
		return "PickAmmo";
	}
	
	virtual inline const std::string name() const
	{
		return "PickAmmo";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize parents
		s += BaseCommand::serialize();
		
		// serialize ammos
		s += __has_ammos;
		if (__has_ammos)
		{
			std::string tmp49 = "";
			unsigned int tmp51 = __ammos.size();
			auto tmp52 = reinterpret_cast<char*>(&tmp51);
			tmp49 += std::string(tmp52, sizeof(unsigned int));
			while (tmp49.size() && tmp49.back() == 0)
				tmp49.pop_back();
			unsigned char tmp54 = tmp49.size();
			auto tmp55 = reinterpret_cast<char*>(&tmp54);
			s += std::string(tmp55, sizeof(unsigned char));
			s += tmp49;
			
			for (auto &tmp56 : __ammos)
			{
				s += '\x01';
				char tmp58 = (char) tmp56.first;
				auto tmp59 = reinterpret_cast<char*>(&tmp58);
				s += std::string(tmp59, sizeof(char));
				
				s += '\x01';
				int tmp61 = tmp56.second;
				auto tmp62 = reinterpret_cast<char*>(&tmp61);
				s += std::string(tmp62, sizeof(int));
			}
		}
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize parents
		offset = BaseCommand::deserialize(s, offset);
		
		// deserialize ammos
		__has_ammos = *((unsigned char*) (&s[offset]));
		offset += sizeof(unsigned char);
		if (__has_ammos)
		{
			unsigned char tmp63;
			tmp63 = *((unsigned char*) (&s[offset]));
			offset += sizeof(unsigned char);
			std::string tmp64 = std::string(&s[offset], tmp63);
			offset += tmp63;
			while (tmp64.size() < sizeof(unsigned int))
				tmp64 += '\x00';
			unsigned int tmp65;
			tmp65 = *((unsigned int*) (&tmp64[0]));
			
			__ammos.clear();
			for (unsigned int tmp66 = 0; tmp66 < tmp65; tmp66++)
			{
				CommandAmmoType tmp67;
				offset++;
				char tmp69;
				tmp69 = *((char*) (&s[offset]));
				offset += sizeof(char);
				tmp67 = (CommandAmmoType) tmp69;
				
				int tmp68;
				offset++;
				tmp68 = *((int*) (&s[offset]));
				offset += sizeof(int);
				
				__ammos[tmp67] = tmp68;
			}
		}
		
		return offset;
	}
};


class PutAmmo : public BaseCommand
{

protected:




public: // getters


public: // reference getters


public: // setters


public: // has_attribute getters


public: // has_attribute setters


public:

	PutAmmo()
	{
	}
	
	static inline const std::string nameStatic()
	{
		return "PutAmmo";
	}
	
	virtual inline const std::string name() const
	{
		return "PutAmmo";
	}
	
	std::string serialize() const
	{
		std::string s = "";
		
		// serialize parents
		s += BaseCommand::serialize();
		
		return s;
	}
	
	unsigned int deserialize(const std::string &s, unsigned int offset=0)
	{
		// deserialize parents
		offset = BaseCommand::deserialize(s, offset);
		
		return offset;
	}
};

} // namespace commands

} // namespace ks

#endif // _KS_COMMANDS_H_
