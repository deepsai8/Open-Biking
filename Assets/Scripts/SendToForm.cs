using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MaterialUI;

public class SendToForm : MonoBehaviour {


	public GameObject userEmail;
	public GameObject userName;
	public GameObject userPhone;
	public GameObject userAddress;
	public GameObject userBikes;
	public GameObject userDays;

	private string email;
	private string name;
	private string phone;
	private string address;
	private string bikes;
	private string days;
	private string price;

	public string timestamp;

	private string RecepientPhone = "9030000802";
	private string sms_body = "How you doing!";

	[SerializeField]
	private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSc-eUmkfBTYWmpgCsndxXXRgICq4ZCA_0NiwwGYWBGzAz2Hyw/formResponse";


	IEnumerator post (string email, string name, string phone, string address, string bikes, string days, string price)
	{
		WWWForm form = new WWWForm();
		form.AddField ("emailAddress", email);
		form.AddField ("entry.2010166585", name);
		form.AddField ("entry.1571872334", phone);
		form.AddField ("entry.1598695910", address);
		form.AddField ("entry.1742182163", bikes);
		form.AddField ("entry.1392767342", days);
		form.AddField ("entry.938259640", price);
		byte[] rawData = form.data;
		WWW www = new WWW (BASE_URL,rawData);

		RecepientPhone =  form.data.GetValue (1).ToString();

		yield return www;

		timestamp = System.DateTime.Now.ToLocalTime().ToString();

	}

	public void Send(){

		int temp=0;
		email = "deepaksx2018@email.iimcal.ac.in";
		name = userName.GetComponent<InputField> ().text;
		phone = userPhone.GetComponent<InputField> ().text;
		address = userAddress.GetComponent<InputField> ().text;

		temp = userBikes.GetComponent<Dropdown> ().value;
		bikes = userBikes.GetComponent<Dropdown> ().options[temp].text;
		temp = userDays.GetComponent<Dropdown> ().value;
		days = userDays.GetComponent<Dropdown> ().options[temp].text;

		price = "50";
		//halting this for now!
		//sendSingleSMS ();
		StartCoroutine (post (email, name, phone, address, bikes, days, price));

	}

	//for sending SMS to single recipient
	public void sendSingleSMS(){    

		//Open the native SMS default app
		Application.OpenURL(string.Format("sms:"+RecepientPhone+"?body="+sms_body));
	}

	// Use this for initialization
	void Start () {
		userBikes.GetComponent<Dropdown> ().captionText.text = "1";
		userDays.GetComponent<Dropdown> ().captionText.text = "1";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
