<template>
  <div class="vault container p-0">
    <!-- VAULT TEMPLATE -->
    <!-- FIXME Router Link text-decoration:none -->
    <router-link :to="{ name: 'vaultdetails', params: { vaultId: vault.id } }">
      <div class="card text-shadow border-warning mb-3" style="max-width: 18rem;">
        <div class="card-body p-0">
          <!-- <span class="d-flex justify-content-between">
            <div class="card-title">Keeps: {{keepsByVault.length}}</div>
            <br />
            <div class="card-title">Others Kept: --</div>
          </span>-->
          <div class="p-2">
            <h5>
              <small>Name:</small>
              {{vault.name}}
            </h5>
          </div>
          <div class="p-2">
            <h6>
              <small>Description:</small>
              {{ vault.description }}
            </h6>
          </div>
        </div>
        <div class="card-footer border-warning">
          <span class="d-flex justify-content-between">
            <i
              class="far fa-trash-alt text-danger"
              title="Delete Vault"
              @click.stop.prevent="deleteVault"
            ></i>
            <small class="card-text text-muted">vId: {{ vault.id }}</small>
            <!-- <i class="fas fa-pencil-alt text-warning" title="Edit Vault" @click="editVault"></i> -->
          </span>
        </div>
      </div>
    </router-link>
    <!-- END VAULT TEMPLATE -->
  </div>
</template>

<script>
import swal from "sweetalert";
export default {
  name: "vault",
  props: ["vault"],
  data() {
    return {};
  },
  async mounted() {
    // This only activates when going into VaultDetails cannot be used when showing all vaults from dashboard.
    await this.$store.dispatch("getKeepsByVaultId", this.$route.params.vaultId);
  },
  computed: {
    keepsByVault() {
      return this.$store.state.keepsByVault;
    }
  },
  methods: {
    addKeepToVault() {},
    deleteVault() {
      swal({
        title: "Are you sure?",
        text:
          "Click 'Ok' to confirm you wish to delete this Vault.  This action cannot be undone.",
        icon: "warning",
        buttons: true,
        dangerMode: true
      }).then(deleteMe => {
        if (deleteMe) {
          let data = this.$store.dispatch("deleteVault", this.vault.id);
          swal("Poof! Your Vault has been removed!", {
            icon: "success"
          });
          // this.editVault = false;
        } else {
          swal("Delete cancelled");
        }
      });
    }
  },

  components: {}
};
</script>

<style scoped></style>
