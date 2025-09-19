using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PasswordDatabase" ,menuName = "PasswordDatabase")]
public class PasswordDatabase : ScriptableObject
{

	[SerializeField]
	private List<PasswordData> passwordLists = new List<PasswordData>();
    

	// パワードリストを返す
	public List<PasswordData> getPasswordLists(){
		return passwordLists;
	}

}








