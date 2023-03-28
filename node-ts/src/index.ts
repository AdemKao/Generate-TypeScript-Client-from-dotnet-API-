import { UserClient } from "./clients";

const URL = "127.0.0.1:5001";
let client = new UserClient(URL);
const callAPI = async () => {
  let users = await client.get();

  users.forEach((user) => console.log(`user Name: ${user.name}`));
};
callAPI();
