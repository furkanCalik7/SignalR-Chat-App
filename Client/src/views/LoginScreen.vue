<template>
  <section class="join-container">
    <div class="join-main">
      <form @submit.prevent="submitUserInfo"></form>
      <div class="username-input">
        <p>Enter an username:</p>
        <!-- Todo ADD here required  -->
        <input type="text" id="username" v-model.trim="username" required />
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
    };
  },
  methods: {
    submitUserInfo() {},
    goChat() {
      this.$router.push({
        name: "chatScreen",
        query: {
          username: this.username,
          room: this.room,
        },
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
