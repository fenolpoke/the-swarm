package com.TFun.TheSwarm;

import com.unity3d.player.*;

/**
 * @deprecated Use UnityPlayerNativeActivity instead.
 */
public class UnityPlayerActivity extends UnityPlayerNativeActivity {

	DevApi devApi;
	String appId = ‘2’;
	@Overridepublic
	void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		devApi = new DevApi(getApplicationContext(), appId);
	}
	
	@Override
	protected void onResume() {
		super.onResume();
		devApi.onResume();
	}
	@Override
	protected void onPause() {
		devApi.onPause();
		super.onPause();
	}
	
}