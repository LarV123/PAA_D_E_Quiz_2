using UnityEngine;
public interface ICharacter : IHitable {

	float MaxHealth {
		get;
	}

	float Health {
		get;
	}

	void Alive();
	void Death();

	void FaceDir(Vector2 dir);

	void AddListener(ICharacterEventListener listener);
	void RemoveListener(ICharacterEventListener listener);
}
