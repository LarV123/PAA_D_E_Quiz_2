public interface IScore {

	int ScoreValue {
		get;
		set;
	}

	void AddScore(int number);
	void SubtractScore(int number);

}
