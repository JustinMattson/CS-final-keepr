<template>
  <div class="keep container p-0">
    <!-- KEEP TEMPLATE -->
    <!-- FIXME Router Link text-decoration:none -->
    <div class="card text-shadow border-info mb-3" style="max-width: 18rem;">
      <div class="card-body p-0">
        <span class="d-flex justify-content-between card-header border-info">
          <span class="card-title">Keeps: {{ keep.keeps }}</span>
          <span class="card-title">Views: {{ keep.views }}</span>
        </span>
        <router-link :to="{ name: 'keepdetails', params: { keepId: keep.id } }">
          <img class="card-img" :src="keep.img" />
        </router-link>
        <div class="p-2">{{ keep.name }}</div>
        <div class="p-2">{{ keep.description }}</div>
      </div>
      <div class="card-footer border-info">
        <span class="d-flex justify-content-between">
          <i
            class="far fa-trash-alt text-danger"
            v-show="keep.isPrivate == true"
            title="Delete Keep"
          ></i>
          <small class="card-text text-muted">kId: {{ keep.id }}</small>
          <!-- TODO Save Keep Link within router -->
          <i class="fas fa-heart text-danger" title="Add to Vault" @click="addKeepToVault"></i>
        </span>
      </div>
    </div>
    <!-- END KEEP TEMPLATE -->
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
        dangerMode: true
      }).then(deleteMe => {
        if (deleteMe) {
          let data = this.$store.dispatch("deleteKeep", this.keep);
          swal("Poof! Your Keep has been removed!", {
            icon: "success"
          });
          // this.editKeep = false;
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
