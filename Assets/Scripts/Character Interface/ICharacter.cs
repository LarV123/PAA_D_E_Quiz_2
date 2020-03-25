using UnityEngine;
public interface ICharacter : IHitable  {

	float Health {
		get;
	}

	float MaxHealth {
		get;
	}

	void Alive();
	void Death();

	void FaceDir(Vector2 dir);

	void AddListener(ICharacterEventListener listener);
	void RemoveListener(ICharacterEventListener listener);
}
