using UnityEngine;
using System.Collections;

public interface ICharacterEventListener {

	void OnAlive(ICharacter character);
	void OnDeath(ICharacter character);
	void OnHealthChange(ICharacter character);

}
