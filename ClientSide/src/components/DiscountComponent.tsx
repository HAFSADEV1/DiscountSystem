import React, { useState, useEffect } from 'react';
import * as signalR from "@microsoft/signalr";

export default function DiscountComponent() {
    const [connection, setConnection] = useState<any>(null);
    const [discountCode, setDiscountCode] = useState('');
    const [isConnected,setIsConnected] = useState(false);
    const [count, setCount] = useState<number>(); 
    const [length, setLength] = useState<number>();
    const [isCodesGenerated,setIsCodesGenerated] = useState(false);
    const [useCodeMsg, setUseCodeMsg] = useState('');

    
    useEffect(() => {
        const newConnection = new signalR.HubConnectionBuilder()
            .withUrl("http://localhost:5146/discountCodeHub")
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, []);

    const startConnection = async () => {
        try {
            await connection.start();
            setIsConnected(true);
        } catch (err) {
            console.log(err);
        }
    };

    const generateCodes = async () => {
        try {
            setIsCodesGenerated(false);
            const response = await connection.invoke("GenerateCodes", count, length);
            setIsCodesGenerated(response);
        } catch (err) {
            console.log(err);
        }
    };

    const useDiscountCode = async () => {
        try {
            if (!discountCode) {
                alert("Please enter a discount code.");
                return;
            }
            
            const response = await connection.invoke("UseCode", discountCode);
            if(response){
                setUseCodeMsg(`server response : ${response} Code used successfully.`);
            }
            else{
                setUseCodeMsg( `server response : ${response} Code not found.`);
            }
        } catch (err) {
            console.log(err);
        }
    };


  return (
    <div className='div-container'>
        <h1 className='title'>Discount system</h1>
        <div>
            <button className='connect' onClick={startConnection}>Connect to the Server</button>
            {isConnected && <p>Server Connected</p>}
        </div>
        <div className='input-group'>
            <h5>Generate discount code : </h5>
            <input type="text" placeholder="Enter the number of codes " value={count} onChange={(e) => setCount(parseInt(e.target.value))} />
            <input type="text" placeholder="Enter Length of the code " value={length} onChange={(e) => setLength(parseInt(e.target.value))} />
            <button onClick={generateCodes}>Generate</button>
            {isCodesGenerated && <p>Server Response True : Code Generated Succefully !</p> }
        </div>

        <div className='input-group'>
            <h5>Use Code : </h5>
            <input type="text" placeholder="Enter discount code..." value={discountCode} onChange={(e) => setDiscountCode(e.target.value)} />
            <button onClick={useDiscountCode} >Use Code</button>
            <p>{useCodeMsg}</p>
        </div>
        {!isConnected &&  <p className='err'>Remarque : please do not Do any action Before connect to the server</p>}
       
    </div>
  )
}
