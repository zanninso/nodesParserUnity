using System;
using System.Collections.Generic;

public abstract class AAction : IAction
{
	protected AAction prevAction;
	protected AAction nextAction;
	protected List<object> parameters;
	protected String title;
	protected int actionParamsCount = 0;

	public AAction()
	{
	}

	public void setPrevAction(AAction action)
	{
		prevAction = action;
	}

	public void setNextAction(AAction action)
	{
		action.setPrevAction(this);
		nextAction = action;
	}

	public void setParam(Object obj)
	{
		parameters.Add(obj);
	}

	public void setParam(Object obj, int index)
	{
		parameters.Insert(index, obj);
	}

	public void setTitle(String title)
	{
		this.title = title;
	}

	public String getTitle()
	{
		return title;
	}	

	public IAction run()
	{
		//checkParams();
		return runAction();
	}

	public virtual void start() {
		GlobalStorage.getInstace().title.text = title;
		GlobalStorage.getInstace().input.text = "";
	}

	//protected abstract void checkParams();
	protected abstract IAction runAction();
}

