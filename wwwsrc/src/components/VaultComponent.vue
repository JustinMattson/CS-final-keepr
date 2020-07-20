<template>
  <div class="vault container p-0">
    <!-- VAULT TEMPLATE -->
    <!-- TODO Router Link to VaultrDetails On Image -->
    <!-- <router-link :to="{ name: 'vaultdetails', params: { id: vault.id } }"> -->
    <div
      class="card shadow rounded-lg bg-dark text-white text-shadow border-warning"
      style="minHeight:100px"
    >
      <!-- <img class="card-img" :src="vault.img" alt="Card image" /> -->
      <div class="card-img-overlay px-3 py-2">
        <div class="card-body txt-shadow p-0">
          <span class="d-flex justify-content-between">
            <div class="card-title">Keeps Count: --</div>
            <div class="card-title">Keeps Mine/Others: ?/?</div>
          </span>
          <div class="text-shadow">
            <small>{{ vault.description }}</small>
          </div>
          <span class="d-flex justify-content-between">
            <small class="card-text text-muted">
              <i
                class="far fa-trash-alt text-danger"
                v-show="vault.isPrivate == true"
                title="Delete Vault"
              ></i>
              kId: {{ vault.id }}</small
            >
            <!-- TODO Save Vault Link within router -->
            <i class="fas fa-heart text-danger" title="I heart this Vault"></i>
          </span>
        </div>
      </div>
    </div>
    <!-- END VAULT TEMPLATE -->
    <!-- </router-link> -->
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
  mounted() {},
  computed: {},
  methods: {},
  deleteVault() {
    swal({
      title: "Are you sure?",
      text:
        "Click 'Ok' to confirm you wish to delete this Vault.  This action cannot be undone.",
      icon: "warning",
      buttons: true,
      dangerMode: true,
    }).then((deleteMe) => {
      if (deleteMe) {
        let data = this.$store.dispatch("deleteVault", this.vault);
        swal("Poof! Your Vault has been removed!", {
          icon: "success",
        });
        // this.editVault = false;
      } else {
        swal("Delete cancelled");
      }
    });
  },
  components: {},
};
</script>

<style scoped></style>
