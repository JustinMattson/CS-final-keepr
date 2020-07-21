<template>
  <li type="button" @click="save">
    <i class="fas fa-long-arrow-alt-right fa-sm text-warning"></i>
    {{vault.name}}
  </li>
</template>


<script>
export default {
  name: "SaveComponent",
  props: ["vault", "keep"],
  data() {
    return {
      saveObj: {
        vaultId: this.vault.id,
        keepId: this.keep.id
      }
    };
  },
  computed: {},
  methods: {
    save() {
      this.$store.dispatch("createVK", this.saveObj);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>