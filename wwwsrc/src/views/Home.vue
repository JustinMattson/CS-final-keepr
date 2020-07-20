<template>
  <div class="home container-fluid p-2">
    <div class="row">
      <div class="col text-center">
        <h1>Welcome to Keepr!</h1>
      </div>
      <!-- add modal to add keep if logged in -->
      <div class="col-12 list-container">
        <div id="keeps" class="card-columns p-2" style="column-gap: 1rem;">
          <!-- KEEP COMPONENTS BEGIN -->
          <keep v-for="keep in keeps" :key="keep.id" :keep="keep" />
          <!-- KEEP COMPONENTS END -->
        </div>
      </div>
    </div>
    <small class="fixed-bottom">
      Made with
      <i class="far fa-heart text-danger" title="Boise Codeworks" /> by Justin
      Mattson!
    </small>
  </div>
</template>

<script>
import Keep from "@/components/KeepComponent.vue";
export default {
  name: "home",
  data() {
    return {
      newKeep: {},
    };
  },
  async mounted() {
    await this.$store.dispatch("getKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.publicKeeps;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  },
  components: {
    Keep,
  },
};
</script>

<style scoped></style>
