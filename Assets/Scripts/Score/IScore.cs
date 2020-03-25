public interface IScore {

	int ScoreValue {
		get;
		set;
	}

	void AddScore(int number);
	void SubtractScore(int number);
	void AddListener(IScoreEventListener listener);
	void RemoveListener(IScoreEventListener listener);

}
