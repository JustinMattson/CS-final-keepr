<template>
  <div class="keepdetails container-fluid">
    <h1>
      <i class="fa fa-h-square" aria-hidden="true"> Keep Details Vue</i>
    </h1>
  </div>
</template>

<script>
export default {
  name: "keepdetails",
  data() {
    return {};
  },
  async mounted() {
    debugger;
    await this.$store.state.dispatch("getKeepById", this.$route.params.keepId);
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    },
  },
  methods: {},
  components: {},
};
</script>

<style scoped></style>
