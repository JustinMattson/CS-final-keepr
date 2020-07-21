<template>
  <div class="keepdetails container-fluid">
    <h1 class="text-center">Keep Details Vue</h1>
    <div class="row d-flex justify-content-center">
      <div class="col-12 col-md-6 py-3">
        <img class="card-img" :src="keep.img" />
      </div>
      <div class="col-12 col-md-6 py-3">
        <small class="text-info">Name:</small>
        {{keep.name}}
        <br />
        <small class="text-info">Description:</small>
        {{keep.description}}
        <br />
        <small class="text-info">Private:</small>
        {{keep.isPrivate}}
        <br />
        <small class="text-info">Views:</small>
        {{keep.views}}
        <br />
        <small class="text-info">Keeps:</small>
        {{keep.keeps}}
        <br />
      </div>
    </div>
    <div class="col-12">
      <small>{{keep}}</small>
    </div>
  </div>
</template>

<script>
export default {
  name: "keepdetails",
  data() {
    return {};
  },
  async mounted() {
    await this.$store.dispatch("getKeepById", this.$route.params.keepId);
  },
  onRouterLeave(to, from, next) {
    commit("setActiveKeep", {});
    next();
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {},
  components: {}
};
</script>

<style scoped></style>
