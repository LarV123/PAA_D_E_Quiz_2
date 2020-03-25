using UnityEngine;
public interface ICharacter  {

	float Health {
		get;
	}

	void Hurt(float damage);

	void Alive();
	void Death();

	void AddListener(ICharacterEventListener listener);
	void RemoveListener(ICharacterEventListener listener);
}
