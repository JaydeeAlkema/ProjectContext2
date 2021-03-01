public interface IClickable
{
	enum ClickableState
	{
		INACTIVE = 0,
		ACTIVE = 1
	}

	public bool clicked { get; set; }

	void Click();
}
