<template>
  <div class="keep container p-0">
    <!-- KEEP TEMPLATE -->
    <!-- TODO Router Link to KeeprDetails On Image -->
    <!-- <router-link :to="{ name: 'keepdetails', params: { id: keep.id } }"> -->
    <div
      class="card shadow rounded-lg bg-dark text-white text-shadow border-info"
      style="minHeight:100px"
    >
      <img class="card-img" :src="keep.img" alt="Card image" />
      <div class="card-img-overlay px-3 py-2">
        <div class="card-body txt-shadow p-0">
          <span class="d-flex justify-content-between">
            <div class="card-title">Keeps: {{ keep.keeps }}</div>
            <div class="card-title">Views: {{ keep.views }}</div>
          </span>
          <div class="text-shadow">
            <small>{{ keep.description }}</small>
          </div>
          <span class="d-flex justify-content-between">
            <small class="card-text text-muted">
              <i
                class="far fa-trash-alt text-danger"
                v-show="keep.isPrivate == true"
                title="Delete Keep"
              ></i>
              kId: {{ keep.id }}</small
            >
            <!-- TODO Save Keep Link within router -->
            <i
              class="fas fa-heart text-danger fa-2x"
              title="Add to Vault"
              @click="addKeepToVault"
            ></i>
          </span>
        </div>
      </div>
    </div>
    <!-- END KEEP TEMPLATE -->
    <!-- </router-link> -->
  </div>
</template>

<script>
import swal from "sweetalert";
export default {
  name: "keep",
  props: ["keep"],
  data() {
    return {};
  },
  mounted() {},
  computed: {},
  methods: {
    addKeepToVault() {
      // this.$store.dispatch("createVaultKeep")
    },
    deleteKeep() {
      swal({
        title: "Are you sure?",
        text:
          "Click 'Ok' to confirm you wish to delete this Keep.  This action cannot be undone.",
        icon: "warning",
        buttons: true,
        dangerMode: true,
      }).then((deleteMe) => {
        if (deleteMe) {
          let data = this.$store.dispatch("deleteKeep", this.keep);
          swal("Poof! Your Keep has been removed!", {
            icon: "success",
          });
          // this.editKeep = false;
        } else {
          swal("Delete cancelled");
        }
      });
    },
  },
  components: {},
};
</script>

<style scoped></style>
