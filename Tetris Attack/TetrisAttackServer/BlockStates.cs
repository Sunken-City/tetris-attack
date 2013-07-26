using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TetrisAttackServer
{
	public enum BlockStates
	{
		AtRest = 1,
		InMotion,
		ClearingInProgress,
		Cleared
	}
}
