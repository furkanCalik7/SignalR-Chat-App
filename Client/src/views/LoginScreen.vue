<template>
  <section class="join-container">
    <div class="join-main">
      <form @submit.prevent="submitUserInfo"></form>
      <div class="username-input">
        <p>Enter an username:</p>
        <input type="text" id="username" v-model.trim="username" required />

        <p>Enter a password:</p>
        <!-- TODO: Change this to password -->
        <input type="text" v-model.trim="password" required />
      </div>
      <div class="room-selection">
        <p for="rooms">Rooms:</p>
        <select v-model="room" id="rooms">
          <option value="bilkent">Bilkent</option>
          <option value="figensoft">Figensoft</option>
          <option value="odtu">ODTU</option>
        </select>
        <button class="btn" @click.prevent="goChat">Login</button>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  data() {
    return {
      username: "",
      room: "bilkent",
      password: "",
      token: "",
    };
  },
  methods: {
    goChat() {
      fetch("https://localhost:5001/dot/authenticate", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          username: this.username,
          password: this.password,
        }),
      })
        .then((response) => {
          if (response.ok) {
            console.log("Response is called");
            return response.json();
          }
          console.error("Response is not ok!");
        })
        .then((data) => {
          this.token = data;
          this.$emit("token", data);
          if (data == null) {
            alert("Username or password is incorrect. Please try again.");
          }
          if (data != null) {
            this.$router.push({
              name: "chatScreen",
              query: {
                username: this.username,
                room: this.room,
              },
            });
          }
        });
    },
  },
  computed: {
    goChatScreen() {
      return {
        name: "chatScreen",
        query: {
          username: this.username,
          room: this.room,
        },
      };
    },
  },
};
</script>
