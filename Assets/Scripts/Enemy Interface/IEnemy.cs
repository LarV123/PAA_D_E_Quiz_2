using UnityEngine;
using System.Collections;

public interface IEnemy {
	int ScoreValue { get; }
	void Attack(ICharacter character);
}
