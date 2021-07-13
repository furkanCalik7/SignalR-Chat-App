<template>
  <div class="chat-sidebar">
    <button class="btn" @click.prevent="LeaveRoom">Leave Room</button>
    <div class="room-name">
      <p>Room: {{ room }}</p>
    </div>
    <div class="user-list">
      <ul class="list">
        <p class="user-list-header">User List</p>
        <li v-for="user in UsersAtThisRoom" :key="user.username">
          <p>{{ user.username }}</p>
        </li>
      </ul>
    </div>
  </div>
</template>


<script>
export default {
  props: ["userlist"],
  data() {
    return {
      room: "",
      usersAt: [],
    };
  },
  computed: {
    UsersAtThisRoom() {
      console.log(this.userlist);
      return this.userlist.filter((user) => user.room === this.room);
    },
  },
  created() {
    this.room = this.$route.query.room;
  },
  methods: {
    LeaveRoom() {
      this.$router.push({ name: "Login" });
    },
  },
};
</script>

<style scoped>
li {
  list-style: none;
}
.room-name {
  padding-top: 30px;
}
.user-list-header {
  padding-top: 30px;
}
</style>