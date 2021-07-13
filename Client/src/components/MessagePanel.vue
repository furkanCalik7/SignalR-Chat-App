<template>
  <div class="chat-form-container">
    <form @submit.prevent="clickSendMessage">
      <input type="text" v-model="text" placeholder="Write message" />
      <button class="btn">Send Message</button>
    </form>
  </div>
  <div class="chat-messages" ref="chat">
    <ul class="message-list">
      <li class="message" v-for="message in messages" :key="message.id">
        <p>{{ message.user }} {{ message.date }}</p>
        <span>{{ message.text }}</span>
      </li>
    </ul>
  </div>
</template>


<script>
export default {
  data() {
    return {
      text: "",
    };
  },
  props: ["messages"],
  methods: {
    clickSendMessage() {
      this.$emit("click-message-button", this.text);
      this.text = "";
    },
    scrollToEnd() {
      var content = this.$refs.chat;
      content.scrollTop = content.scrollHeight;
    },
  },
  updated() {
    this.scrollToEnd();
  },
  emits: ["click-message-button"],
};
</script>


<style scoped>
/* .message-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: flex-start;
  overflow: hidden;
  overflow-y: scroll;
  height: 450px;
}
.messages {
  display: grid;
  overflow: hidden;
}
ul {
  list-style: none;
}
li {
  width: 300px;
  padding: 5px;
}
p {
  text-decoration: none;
  color: blueviolet;
  font-style: italic;
} */
</style>