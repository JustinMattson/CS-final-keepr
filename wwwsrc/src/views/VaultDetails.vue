<template>
  <div class="vaultdetails container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>Vault Details Vue</h1>
        Vault Name: {{vault.name}}
        <br />
        Vault Description: {{vault.description}}
        <!-- TODO insert means to edit vault info -->
        <br />
        <small class="text-muted">Keeps stored in this vault will be displayed here</small>
      </div>
      <!-- Display keeps within this vault -->
      <!-- This will be from the vaultKeeps table -->
      <div class="col-12 list-container d-flex justify-content-center">
        <div id="keeps" class="card-columns p-2" style="column-gap: 1rem;">
          <!-- KEEP COMPONENTS BEGIN -->
          <keep
            v-for="keep in publicKeeps"
            :key="keep.id"
            :keep="keep"
            v-show="publicKeeps.id == vaultKeep.keepId"
          />
          <!-- KEEP COMPONENTS END -->
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "@/components/KeepComponent.vue";
export default {
  name: "vaultdetails",
  data() {
    return {};
  },
  async mounted() {
    await this.$store.dispatch("getUserVKs");
    await this.$store.dispatch("getVaultById", this.$route.params.vaultId);
    await this.$store.dispatch("getKeeps");
  },
  onRouterLeave(to, from, next) {
    commit("setActiveVault", {});
    next();
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    },
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {},
  components: {
    Keep
  }
};
</script>

<style scoped></style>
