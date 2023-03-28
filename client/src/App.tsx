import { useState } from "react";
import reactLogo from "./assets/react.svg";
import "./App.css";
import "./clients";
import { UserClient, UserModel } from "./clients";
import axios from "axios";
import $ from "jquery";

function App() {
  const URL = "http://127.0.0.1:5001";
  const [title, setTitle] = useState<string>();
  const [result, setResult] = useState<UserModel[]>();
  let userClient = new UserClient(URL);

  const usingGeneratePackage = async () => {
    let result = await userClient.get();
    console.log("usingGeneratePackage", result);
    setTitle("Using Client Generator");
    setResult(result);
  };
  const usingFetch = async () => {
    let res = await fetch(`${URL}/User`, { method: "GET" });
    let result = await res.json();
    console.log("usingFetch", res, result);
    setTitle("Using Fetch");
    setResult(result);
  };
  const usingAxios = async () => {
    let res = await axios(`${URL}/User`, { method: "GET" });
    let result = await res.data;
    console.log("usingAxios", res, result);
    setTitle("Using Axios");
    setResult(result);
  };
  const usingJQuery = async () => {
    let res = await $.ajax(`${URL}/User`, { method: "GET" });
    let result = res;
    console.log("usingJQuery", res, result);
    setTitle("Using JQuery");
    setResult(result);
  };
  const clear = () => {
    setResult(undefined);
    setTitle("Select one method to query api");
  };

  return (
    <div className="App">
      <h3>Demo Generate API using Different method to call API</h3>
      <div className="Result">
        <div>{title}</div>
        {result &&
          result.map((res, index) => (
            <div key={index}>
              <div>User Name:{res.name}</div>
              <div>User Email:{res.email}</div>
            </div>
          ))}
      </div>
      <button className="Button" onClick={clear}>
        clear
      </button>
      <hr />
      <div className="Buttons">
        <button onClick={usingGeneratePackage}>usingGeneratePackage</button>
        <button onClick={usingFetch}>fetch</button>
        <button onClick={usingAxios}>axios</button>
        <button onClick={usingJQuery}>jquery</button>
      </div>
    </div>
  );
}

export default App;
