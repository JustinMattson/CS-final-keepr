<template>
  <div class="vaultdetails container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>{{vault.name}}</h1>
        <!-- Vault Name: {{vault.name}}
        <br />-->
        <span class="text-muted">Vault Description:</span>
        {{vault.description}}
        <!-- TODO insert means to edit vault info -->
        <br />

        <small
          class="text-muted"
          v-show="keepsByVault.length < 1"
        >Keeps stored in this vault will be displayed here</small>
      </div>
      <!-- Display keeps within this vault -->
      <!-- This will be from the vaultKeeps table -->
      <div class="col-12 list-container d-flex justify-content-center">
        <div id="keeps" class="card-columns p-2" style="column-gap: 1rem;">
          <!-- KEEP COMPONENTS BEGIN -->
          <keep v-for="keep in keepsByVault" :key="keep.id" :keep="keep" />
          <!-- v-show="publicKeeps.id == vaultKeeps.keepId && vault.id == vaultKeeps.vaultId" -->
          <!-- KEEP COMPONENTS END -->
        </div>
      </div>
      <div class="col-12">
        <i class="far fa-trash-alt text-danger action" @click="deleteVault"></i>
        <small>&nbsp;Delete Vault</small>
        <br />
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "@/components/KeepComponent.vue";
import swal from "sweetalert";
export default {
  name: "vaultdetails",
  data() {
    return {};
  },
  async mounted() {
    await this.$store.dispatch("getUserVKs");
    await this.$store.dispatch("getVaultById", this.$route.params.vaultId);
    await this.$store.dispatch("getKeeps");
    await this.$store.dispatch("getKeepsByVaultId", this.$route.params.vaultId);
    // await this.$store.dispatch("getUserVaults");
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
    },
    keepsByVault() {
      return this.$store.state.keepsByVault;
    }
    // myVaults() {
    //   return this.$store.state.myVaults;
    // }
  },
  methods: {
    deleteVault() {
      swal({
        title: "Are you sure?",
        text:
          "Click 'Ok' to confirm you wish to delete this Vault.  This action cannot be undone.",
        icon: "error",
        buttons: true,
        dangerMode: true
      }).then(removeVault => {
        if (removeVault) {
          let data = this.$store.dispatch(
            "deleteVault",
            this.$route.params.vaultId
          );
          swal("Poof! Vault has been deleted!", {
            icon: "success"
          });
        } else {
          swal("Delete cancelled");
        }
      });
    }
  },
  components: {
    Keep
  }
};
</script>

<style scoped></style>
