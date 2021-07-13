<template>
  <div class="chat-container">
    <div class="chat-main">
      <user-list class="chat-sidebar" :userlist="userList"></user-list>
      <div>
        <message-panel
          @click-message-button="sendMessage"
          :messages="messages"
        ></message-panel>
      </div>
    </div>
  </div>
</template>


<script>
import UserList from "../components/UserList.vue";
import MessagePanel from "../components/MessagePanel.vue";
const signalR = require("@microsoft/signalr");

export default {
  components: {
    UserList,
    MessagePanel,
  },
  data() {
    return {
      userList: [],
      messages: [],
      connection: null,
      username: this.$route.query.username,
      room: this.$route.query.room,
    };
  },
  mounted() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:5001/chatHub")
      .build();

    this.connection.on("receiveMessage", (message) => {
      this.messages.push(message);
    });
    this.connection.on("updateUsers", (users) => {
      this.userList = users;
    });
    this.connection.start().then(() => {
      this.connection
        .invoke("CreateUser", this.username, this.room)
        .then(() => {
          this.connection.invoke("ManifestNewUser", this.username, this.room);
        });
    });
  },
  beforeUnmount() {
    this.connection.invoke("RemoveUser", this.username, this.room).then(() => {
      this.connection.stop();
    });
  },
  methods: {
    sendMessage(messageInfo) {
      this.connection.invoke(
        "sendMessage",
        this.username,
        messageInfo,
        this.room
      );
    },
  },
};
</script>
