using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Healthbar : MonoBehaviour, ICharacterEventListener {

	private Image fill;
	private float fullWidth;

	[SerializeField] private GameObject character;

	void Start() {
		fill = transform.GetChild(1).GetComponent<Image>();
		fullWidth = fill.rectTransform.localScale.x;
		if(character != null)
			character.GetComponent<ICharacter>().AddListener(this);
	}
	
	void Update() {

	}

	public void OnAlive(ICharacter character) {

	}

	public void OnDeath(ICharacter character) {

	}

	public void OnHealthChange(ICharacter character) {
		Vector3 localScale = fill.rectTransform.localScale;
		localScale.x = fullWidth * character.Health / character.MaxHealth;
		fill.rectTransform.localScale = localScale;
	}
}
