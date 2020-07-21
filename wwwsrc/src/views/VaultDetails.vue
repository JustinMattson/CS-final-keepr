<template>
  <div class="vaultdetails container-fluid">
    <h1>Vault Details Vue</h1>
    Vault Name: {{vault.name}}
    <br />
    Vault Description: {{vault.description}}
    <!-- TODO insert means to edit vault info -->
    <br />

    <!-- Display keeps within this vault -->
    <!-- This will be from the vaultkeeps table -->
    <small class="text-muted">Keeps stored in this vault will be displayed here</small>
  </div>
</template>

<script>
export default {
  name: "vaultdetails",
  data() {
    return {};
  },
  async mounted() {
    await this.$store.dispatch("getVaultById", this.$route.params.vaultId);
  },
  onRouterLeave(to, from, next) {
    commit("setActiveVault", {});
    next();
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    }
  },
  methods: {},
  components: {}
};
</script>

<style scoped></style>
