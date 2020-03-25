using UnityEngine;
using System.Collections;

public interface ICharacterEventListener {
	
	void OnHealthChange(ICharacter character);
	void OnAlive(ICharacter character);
	void OnDeath(ICharacter character);

}
