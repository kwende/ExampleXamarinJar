package com.ocuvera.hellojava;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import android.media.AudioManager;
import android.Manifest;
import android.content.pm.PackageManager;

import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.azure.android.communication.common.CommunicationIdentifier;
import com.azure.android.communication.common.CommunicationUserIdentifier;
import com.azure.android.communication.common.CommunicationTokenCredential;
import com.azure.android.communication.calling.CallAgent;
import com.azure.android.communication.calling.Call;
import com.azure.android.communication.calling.CallClient;
import com.azure.android.communication.calling.StartCallOptions;

import java.util.Arrays;
import java.util.concurrent.ExecutionException;

public class Acs {

    private CallAgent _callAgent;
    private Call _call;

    public int doIt(){
        return 5;
    }

    public String startCall(android.content.Context context, String callerAcsToken, String calleeAcsUserId)
            throws InterruptedException, ExecutionException  {

        CallClient callClient = new CallClient();
        CommunicationTokenCredential credential = new CommunicationTokenCredential(callerAcsToken);
        _callAgent = callClient.createCallAgent(context,credential).get();

        _call = _callAgent.startCall(
                context,
                Arrays.asList(new CommunicationUserIdentifier[]{new CommunicationUserIdentifier(calleeAcsUserId)}),
                new StartCallOptions());

        return "done";
    }

    public String getCallState(){
        return _call.getState().toString();
    }

}
